namespace Hackerrank.BotBuilding
{
    using System;

    using Hackerrank.Utils.Grid;

    using NUnit.Framework;

    [TestFixture]
    class BotCleanPartiallyObservable : BaseTest
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
            DiscretePoint hidden = null;
            do
            {
                dirty = FindNextClosestDirty(grid, bot);
                Directions dir;
                if (dirty != null)
                {
                    
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
                else
                {
                    hidden = FindFurthestHidden(grid, bot);
                    if (hidden != null)
                    {
                        dir = GridUtils.GetBotDirection(bot, hidden);
                        bot.Move(dir);
                    }
                }
            }
            while (dirty != null || hidden != null);
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

    }
}
