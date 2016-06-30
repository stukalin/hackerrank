using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank.WeekOfCode21
{
    using Hackerrank.Utils;

    using NUnit.Framework;

    [TestFixture]
    class LazySorting
    {
        [TestCase(new[] { 2, 5 }, ExpectedResult = "2.000000")]
        [TestCase(new[] { 2, 5, 3 }, ExpectedResult = "0.240000")]
        [TestCase(new[] { 2, 5, 3, 4, 10, 11, 12, 13 }, ExpectedResult = "0.000025")]
        [TestCase(new[] { 2, 5, 3, 4, 10, 11, 12, 13, 14, 15 }, ExpectedResult = "0.000025")]
        public string Sol(int[] input)
        {
            var n = PermutNumber(input);
            //Console.WriteLine(n);

            double r = 1.0 / n;
            double sum = r / ((1 - r) * (1 - r));

            // Console.WriteLine("{0:F6}", sum);
            return string.Format("{0:F6}", Math.Round(sum, 6, MidpointRounding.AwayFromZero));
        }

        [TestCase(new[] {2,5}, ExpectedResult = 2)]
        [TestCase(new[] {2,2}, ExpectedResult = 1)]
        [TestCase(new[] {2,5,1}, ExpectedResult = 6)]
        [TestCase(new[] {2,5,1,1,2}, ExpectedResult = 30)]
        public int PermutNumberTest(int[] a)
        {
            return PermutNumber(a);
        }

        public static int PermutNumber(int[] input)
        {
            var groups = input.GroupBy(a => a);
            var denom = 1L;
            foreach (var g in groups)
            {
                denom *= MathUtil.Factorial(g.Count());
            }

            return (int)(MathUtil.Factorial(input.Length) / denom);
        }
    }
}
