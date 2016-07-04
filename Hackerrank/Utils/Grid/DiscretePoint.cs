namespace Hackerrank.Utils.Grid
{
    public class DiscretePoint
    {
        public DiscretePoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void Move(Directions d)
        {
            switch (d)
            {
                case Directions.Left:
                    this.X--;
                    break;
                case Directions.Down:
                    this.Y++;
                    break;
                case Directions.Up:
                    this.Y--;
                    break;
                case Directions.Right:
                    this.X++;
                    break;
            }
        }
    }
}