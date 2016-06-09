using System;
using System.Collections.Generic;

namespace Hackerrank.BotBuilding
{
    using NUnit.Framework;

    [TestFixture]
    class BotSavesPrincess : BaseTest
    {
        private int minDepth;
        private Directions[] minPath;

        internal enum Directions : byte
        {
            Left,
            Right,
            Up, 
            Down
        }

        [TestCase("----m-p--", 3)]
        public void Solution(string input, int n)
        {
            var arr = new char[n, n];
            int x = 0, y = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = input[i * n + j];
                    if (arr[i, j] == 'm')
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            minDepth = int.MaxValue;
            FindPrincess(arr, x, y, 0, new Stack<Directions>());

            foreach (var directionse in minPath)
            {
                Console.WriteLine(directionse.ToString().ToUpper());
            }
        }

        public bool FindPrincess(char[,] maze, int x, int y, int depth, Stack<Directions> path)
        {
            if (depth >= minDepth)
            {
                return false;
            }

            var len = maze.GetLength(0);
            if (maze[x, y] == 'p')
            {
                minDepth = depth;
                minPath = path.ToArray();
                return true;
            }

            maze[x, y] = 'v';

            if (x - 1 >= 0 && maze[x - 1, y] != 'v')
            {
                path.Push(Directions.Up);
                FindPrincess(maze, x - 1, y, depth + 1, path);
                path.Pop();
            }

            if (x + 1 < len && maze[x + 1, y] != 'v')
            {
                path.Push(Directions.Down);
                FindPrincess(maze, x + 1, y, depth + 1, path);
                path.Pop();
            }

            if (y - 1 >= 0 && maze[x, y - 1] != 'v')
            {
                path.Push(Directions.Left);
                FindPrincess(maze, x, y - 1, depth + 1, path);
                path.Pop();
            }

            if (y + 1 < len && maze[x, y + 1] != 'v')
            {
                path.Push(Directions.Right);
                FindPrincess(maze, x, y + 1, depth + 1, path);
                path.Pop();
            }

            maze[x, y] = '-';
            return false;
        }
    }
}
