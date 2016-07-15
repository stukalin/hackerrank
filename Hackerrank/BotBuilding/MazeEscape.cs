namespace Hackerrank.BotBuilding
{
    using System;

    using Hackerrank.Utils.Grid;

    using NUnit.Framework;

    [TestFixture]
    class MazeEscape : MazeEnvEscape
    {
        [TestCase("########--#--##--#-b##--#--#e-----##-----########", 7, 2, 5)]
        public void Solution(string input, int n, int x, int y)
        {
            var arr = GenerateGrid(input, n, n);
            var bot = new DiscretePoint(x, y);

            Solve(arr, bot, true);
        }

        public override string NextStep(char[,] grid, DiscretePoint bot)
        {
            throw new NotImplementedException();
        }

        public override bool CheckIfSolved(char[,] grid, DiscretePoint bot)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 'e')
                    {
                        return i == bot.I && j == bot.J;
                    }
                }
            }

            return false;
        }
    }
}
