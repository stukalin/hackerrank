namespace Hackerrank.Projecteuler
{
    using System;
    using System.Linq;

    using Hackerrank.Utils;

    using NUnit.Framework;

    [TestFixture]
    class ProjectEuler2 : BaseTest
    {
        [TestCase(10, ExpectedResult = 10)]
        [TestCase(100, ExpectedResult = 44)]
        public long Solution(long n)
        {
            return MathUtil.FibUpto(n).Where(b => b % 2 == 0).Sum();
        }

        [TestCase(10, ExpectedResult = 8)]
        [TestCase(90, ExpectedResult = 89)]
        [TestCase(70, ExpectedResult = 55)]
        public long FibTest(long n)
        {
            return MathUtil.LastFibUpto(n);
        }
    }
}
