namespace Hackerrank.BotBuilding
{
    using System;

    using Hackerrank.Utils.Grid;

    abstract class MazeEnv : BaseTest
    {
        public abstract string NextStep(char[,] grid, DiscretePoint bot);

        public abstract bool CheckIfSolved(char[,] grid);

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

        public void Solve(char[,] grid, DiscretePoint bot)
        {
            while (!CheckIfSolved(grid))
            {
                var cmd = NextStep(grid, bot);
                Log.Info(cmd);
                ChangeEnv(grid, bot, cmd);
            }
        }
    }
}
