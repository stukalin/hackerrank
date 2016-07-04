namespace Hackerrank.Utils.Grid
{
    using System;

    public static class GridUtils
    {
        public static Directions GetBotDirection(DiscretePoint bot, DiscretePoint obj)
        {
            return GetBotDirection(bot.X, bot.Y, obj.X, obj.Y);
        }

        public static Directions GetBotDirection(int botx, int boty, int objx, int objy)
        {
            var deltax = objx - botx;
            var deltay = objy - boty;

            if (Math.Abs(deltax) > Math.Abs(deltay))
            {
                return deltax > 0 ? Directions.Right : Directions.Left;
            }

            if (deltay > 0)
            {
                return Directions.Down;
            }

            if (deltay < 0)
            {
                return Directions.Up;
            }

            return Directions.Stop;
        }

        public static double Distance(DiscretePoint a, DiscretePoint b)
        {
            return Distance(a.X, a.Y, b.X, b.Y);
        }

        public static double Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
