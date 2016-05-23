namespace Hackerrank.Projecteuler
{
    using System;
    using System.Diagnostics;

    using NUnit.Framework;

    /// <summary>
    /// Investigating progressive numbers, n, which are also square.
    /// </summary>
    [TestFixture]
    public class ProjectEuler141
    {
        [TestCase(58, ExpectedResult = true)]
        [TestCase(9, ExpectedResult = true)]
        [TestCase(10404, ExpectedResult = true)]
        [TestCase(100000000000, ExpectedResult = false)]
        public bool FindIfProgressive(long n)
        {
            return IsProgressive(n);
        }

        [TestCase(1000000)]
        public void ListProgressivesUpTo(long n)
        {
            for (long i = n; i >= 2; i--)
            {
                if (IsProgressive(i))
                {
                    continue;
                    //Console.WriteLine(i);
                }
            }
        }

        private static bool IsProgressive(long n)
        {
            bool isProgressive = false;
            var upperMultiplier = (long)Math.Floor(Math.Sqrt(n));

            for (long m1 = upperMultiplier; m1 >= 2 ; m1--)
            {                
                long m2 = n / m1;
                long rest = n % m1;

                if (rest == 0)
                {
                    continue;
                }

                isProgressive = Math.Abs(m2 / (double)m1 - m1 / (double)rest) < 1e-8;

                if (isProgressive)
                {
                    //Console.WriteLine("{0} * {1} + {2} = {3} with factor {4:F}. Time: {5}", m2, m1, rest, n, m2 / (double)m1, sw.ElapsedMilliseconds);
                    break;
                }
            }

            return isProgressive;
        }
    }
}
