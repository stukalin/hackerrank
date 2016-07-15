namespace Hackerrank.BotBuilding
{
    using System;

    using Hackerrank.Utils.Grid;

    using NUnit.Framework;

    [TestFixture]
    class BotCleanPartiallyObservable : MazeEnv
    {
        [TestCase("----d-d--d--dd---d------d", 5, 0, 0)]
        public void Solution(string input, int n, int x, int y)
        {
            var arr = GenerateGrid(input, n, n);
            var bot = new DiscretePoint(x, y);

            Solve(arr, bot, true);
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
                            dirty = new DiscretePoint(j, i);
                        }
                    }
                }
            }

            return dirty;
        }

        static DiscretePoint FindFurthestHidden(char[,] grid, DiscretePoint bot)
        {
            DiscretePoint dirty = null;
            double max = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 'o')
                    {
                        var distance = GridUtils.Distance(bot.X, bot.Y, j, i);
                        if (distance > max)
                        {
                            max = distance;
                            dirty = new DiscretePoint(j, i);
                        }
                    }
                }
            }

            return dirty;
        }

        public override string NextStep(char[,] grid, DiscretePoint bot)
        {
            // check if file exists
            if (!this.CheckIfFileExists())
            {
                SaveFile(grid);
            }

            var cleangrid = this.ReadFile();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    CheckAndCopy(grid, cleangrid, bot.Y + i, bot.X + j);
                }
            }

            SaveFile(cleangrid);

            DiscretePoint dirty = null;
            dirty = FindNextClosestDirty(cleangrid, bot);
            Directions dir;
            if (dirty != null)
            {
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
            else
            {
                var hidden = FindFurthestHidden(cleangrid, bot);
                if (hidden != null)
                {
                    dir = GridUtils.GetBotDirection(bot, hidden);
                    return dir.ToString().ToUpper();
                }
            }

            return null;
        }

        public override bool CheckIfSolved(char[,] grid, DiscretePoint bot)
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
