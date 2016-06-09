namespace Hackerrank.BotBuilding
{
    using NUnit.Framework;

    [TestFixture]
    class BotSavesPrincess : BaseTest
    {

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

            FindPrincess(arr, x, y);
        }

        public bool FindPrincess(char[,] maze, int x, int y)
        {
            var len = maze.GetLength(0);
            if (maze[x, y] == 'p')
            {
                Log.InfoFormat("found at {0}; {1}", x, y);
                return true;
            }

            maze[x, y] = 'v';
            
                // possible to go
                if (x-1 >=0 && maze[x - 1, y] != 'v')
                {
                    if (FindPrincess(maze, x - 1, y))
                    {
                        Log.InfoFormat("up to {0}; {1}", x - 1, y);
                        return true;
                    }
                }

                // possible to go
                if (x + 1 < len && maze[x + 1, y] != 'v')
                {
                    if (FindPrincess(maze, x + 1, y))
                    {
                        Log.InfoFormat("down to {0}; {1}", x + 1, y);
                        return true;
                    }
                }

                // possible to go
                if (y - 1 >= 0 && maze[x, y - 1] != 'v')
                {
                    if (FindPrincess(maze, x, y - 1))
                    {
                        Log.InfoFormat("left to {0}; {1}", x, y-1);
                        return true;
                    }
                }

                // possible to go
                if (y + 1 < len && maze[x, y + 1] != 'v')
                {
                    if (FindPrincess(maze, x, y + 1))
                    {
                        Log.InfoFormat("right to {0}; {1}", x, y+1);
                        return true;
                    }
                }

            maze[x, y] = '-';
            return false;
        }
    }
}
