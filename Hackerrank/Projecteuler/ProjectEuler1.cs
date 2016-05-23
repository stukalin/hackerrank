namespace Hackerrank.Projecteuler
{
    using NUnit.Framework;

    /// <summary>
    /// Multiples of 3 and 5
    /// </summary>
    [TestFixture]
    public class ProjectEuler1
    {
        [TestCase(10, ExpectedResult = 23)]
        [TestCase(100, ExpectedResult = 2318)]
        public long Solution(int n)
        {
            long three = 0;
            long five = 0;
            long fteen = 0;

            if (n <= 3)
            {
                three = 0;
            }
            else if (n <= 6)
            {
                three = 3;
            }
            else
            {
                long a = (n - 1) / 3;
                three = (3 + 3 * a) * a / 2;
            }

            if (n <= 5)
            {
                five = 0;
            }
            else if (n <= 10)
            {
                five = 5;
            }
            else
            {
                long a = (n - 1) / 5;
                five = (5 + 5 * a) * a / 2;
            }

            if (n <= 15)
            {
                fteen = 0;
            }
            else if (n <= 30)
            {
                fteen = 15;
            }
            else
            {
                long a = (n - 1) / 15;
                fteen = (15 + 15 * a) * a / 2;
            }

            return three + five - fteen;
        }
    }
}
