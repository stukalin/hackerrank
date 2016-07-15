namespace Hackerrank.BotBuilding
{
    using System;
    using System.Linq;

    using Hackerrank.Utils.Grid;

    abstract class MazeEnv : BaseTest
    {
        private bool fileExists = false;

        private string[] file;

        public abstract string NextStep(char[,] grid, DiscretePoint bot);

        public abstract bool CheckIfSolved(char[,] grid, DiscretePoint bot);

        public char[,] GenerateGrid(string s, int h, int w)
        {
            var arr = new char[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    arr[i, j] = s[i * w + j];
                }
            }

            return arr;
        }

        public virtual void ChangeEnv(char[,] grid, DiscretePoint bot, string command)
        {
            Directions dir;
            if (Enum.TryParse(command, true, out dir))
            {
                bot.Move(dir);
            }

            if (command == "CLEAN")
            {
                if (grid[bot.Y, bot.X] == 'd')
                {
                    grid[bot.Y, bot.X] = '-';
                }
            }
        }

        public void Solve(char[,] grid, DiscretePoint bot, bool restrict = false, int maxSteps = 100)
        {
            int steps = 0;
            while (!CheckIfSolved(grid, bot) && steps <= maxSteps)
            {
                var restrictView = this.RestrictView(grid, bot, restrict);
                PrintMaze(restrictView, bot);
                var cmd = NextStep(restrictView, bot);
                Log.Info(cmd);
                ChangeEnv(grid, bot, cmd);

                steps++;
            }
        }

        public bool CheckIfFileExists()
        {
            return this.fileExists;
        }

        public char[,] ReadFile()
        {
            var hw = this.file[0].Split(' ').Select(int.Parse).ToArray();
            var h = hw[0];
            var w = hw[1];

            return GenerateGrid(this.file[1], h, w);
        }

        public void SaveFile(char[,] grid)
        {
            int h = grid.GetLength(0);
            int w = grid.GetLength(1);
            string s = "";
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    s += grid[i, j];
                }
            }

            this.file = new string[2];
            this.file[0] = string.Format("{0} {1}", h, w);
            this.file[1] = s;

            this.fileExists = true;
        }

        protected virtual char[,] RestrictView(char[,] source, DiscretePoint bot, bool restrict)
        {
            if (!restrict)
            {
                return source;
            }

            char[,] grid = new char[source.GetLength(0), source.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 'o';
                }
            }

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    CheckAndCopy(source, grid, bot.Y + i, bot.X + j);
                }
            }

            return grid;
        }

        protected void CheckAndCopy(char[,] source, char[,] destination, int i, int j)
        {
            if (0 <= i && i < source.GetLength(0) && 0 <= j && j < source.GetLength(1))
            {
                destination[i, j] = source[i, j];
            }
        }

        private void PrintMaze(char[,] grid, DiscretePoint bot)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                string s = "";
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == bot.Y && j == bot.X)
                    {
                        s += 'b';
                    }
                    else
                    {
                        s += grid[i, j];
                    }
                }

                Log.Info(s);
            }
        }
    }
}
