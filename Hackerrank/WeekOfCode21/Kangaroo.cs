namespace Hackerrank.WeekOfCode21
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    class Kangaroo
    {
        [TestCase(0, 3, 4, 2, ExpectedResult = "YES")]
        [TestCase(0, 3334, 9999, 1, ExpectedResult = "YES")]
        [TestCase(0, 3333, 9999, 1, ExpectedResult = "NO")]
        [TestCase(0, 5, 4, 2, ExpectedResult = "NO")]
        [TestCase(0, 2, 5, 3, ExpectedResult = "NO")]
        [TestCase(0, 2, 5, 2, ExpectedResult = "NO")]
        [TestCase(5, 2, 5, 2, ExpectedResult = "YES")]
        public string Solution(int x1, int v1, int x2, int v2)
        {
            if (v2 > v1)
            {
                return "NO";
            }

            if (v2 == v1)
            {
                return x2 == x1 ? "YES" : "NO";
            }

            double a = 1.0 * (x2 - x1) / (v1 - v2);
            return Math.Abs(a % 1) < Double.Epsilon ? "YES" : "NO";
        }
    }
}
