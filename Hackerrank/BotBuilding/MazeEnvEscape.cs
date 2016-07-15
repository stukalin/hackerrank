namespace Hackerrank.BotBuilding
{
    using Hackerrank.Utils.Grid;

    abstract class MazeEnvEscape : MazeEnv
    {
        protected override char[,] RestrictView(char[,] source, DiscretePoint bot, bool restrict)
        {
            if (!restrict)
            {
                return source;
            }

            char[,] grid = new char[3, 3];

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    CheckAndCopy(source, grid, bot.Y + i, bot.X + j);
                }
            }

            return grid;

        }
    }
}