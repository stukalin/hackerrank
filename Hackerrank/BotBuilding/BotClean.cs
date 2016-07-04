namespace Hackerrank.BotBuilding
{
    using System;

    using Hackerrank.Utils.Grid;

    using NUnit.Framework;

    [TestFixture]
    class BotClean : MazeEnv
    {
        [TestCase("b---d-d--d--dd---d------d", 5, 0, 0)]
        public void Solution(string input, int n, int x, int y)
        {
            var arr = new char[n, n];
            var bot = new DiscretePoint(x, y);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = input[i * n + j];
                }
            }

            Solve(arr, bot);
        }

        static DiscretePoint FindNextClosestDirty(char[,] grid, DiscretePoint bot)
        {
            DiscretePoint dirty = null;
            double min = double.MaxValue;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 'd')
                    {
                        var distance = GridUtils.Distance(bot.X, bot.Y, j, i);
                        if (distance < min)
                        {
                            min = distance;
                            dirty = new DiscretePoint(j,i);
                        }
                    }
                }
            }

            return dirty;
        }

        public override string NextStep(char[,] grid, DiscretePoint bot)
        {
            DiscretePoint dirty = null;
            dirty = FindNextClosestDirty(grid, bot);
            if (dirty != null)
            {
                Directions dir;
                dir = GridUtils.GetBotDirection(bot, dirty);
                if (dir != Directions.Stop)
                {
                    return dir.ToString().ToUpper();
                }
                else
                {
                    return "CLEAN";
                }
            }

            return null;
        }

        public override bool CheckIfSolved(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 'd')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
