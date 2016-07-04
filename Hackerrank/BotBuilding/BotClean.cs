namespace Hackerrank.BotBuilding
{
    using System;

    using Hackerrank.Utils.Grid;

    using NUnit.Framework;

    [TestFixture]
    class BotClean : BaseTest
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

            CleanAll(arr, bot);
        }

        static void CleanAll(char[,] grid, DiscretePoint bot)
        {
            DiscretePoint dirty = null;
            do
            {
                dirty = FindNextClosestDirty(grid, bot);
                if (dirty != null)
                {
                    Directions dir;
                    do
                    {
                        dir = GridUtils.GetBotDirection(bot, dirty);
                        if (dir != Directions.Stop)
                        {
                            Console.WriteLine(dir.ToString().ToUpper());
                        }
                        else
                        {
                            Console.WriteLine("CLEAN");
                            grid[dirty.Y, dirty.X] = '-';
                        }
                        bot.Move(dir);
                    }
                    while (dir != Directions.Stop);
                }
            }
            while (dirty != null);
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
    }
}
