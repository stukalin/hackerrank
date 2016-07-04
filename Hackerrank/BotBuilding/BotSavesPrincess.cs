using System;
using System.Collections.Generic;

namespace Hackerrank.BotBuilding
{
    using Hackerrank.Utils.Grid;

    using NUnit.Framework;

    [TestFixture]
    class BotSavesPrincess : BaseTest
    {
        [TestCase("----m-p--", 3)]
        public void Solution(string input, int n)
        {
            var arr = new char[n, n];
            DiscretePoint bot = null;
            DiscretePoint princess = null;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = input[i * n + j];
                    if (arr[i, j] == 'm')
                    {
                        bot = new DiscretePoint(j, i);
                    }

                    if (arr[i, j] == 'p')
                    {
                        princess = new DiscretePoint(j, i);
                    }
                }
            }

            DisplayPathtoPrincess(n, arr, bot, princess);
        }

        static void DisplayPathtoPrincess(int n, char[,] grid, DiscretePoint bot, DiscretePoint princess)
        {
            List<Directions> directionses = new List<Directions>();
            Directions dir;
            do
            {
                dir = GridUtils.GetBotDirection(bot, princess);
                if (dir != Directions.Stop)
                {
                    directionses.Add(dir);
                }
                bot.Move(dir);
            }
            while (dir != Directions.Stop);

            foreach (var directionse in directionses)
            {
                Console.WriteLine(directionse.ToString().ToUpper());
            }
        }
    }
}
