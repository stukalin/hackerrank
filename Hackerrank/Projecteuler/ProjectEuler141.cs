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

        [TestCase(1000000000)]
        public void ListProgressivesUpTo(long n)
        {
            long prevsquare = 1;
            long prevsquareroot = 1;

            while (prevsquare <= n)
            {
                prevsquareroot++;
                prevsquare = prevsquare + 2 * prevsquareroot - 1;
                IsProgressive(prevsquare);
                //Console.WriteLine("{0}^2 = {1}", prevsquareroot, prevsquare);
            }
                        
        }

        bool IsPerfectSquare(long input)
        {
            long closestRoot = (long)Math.Sqrt(input);
            return input == closestRoot * closestRoot;
        }

        private static bool IsProgressive(long n)
        {
            bool isProgressive = false;
            long upperMultiplier = (long)Math.Floor(Math.Sqrt(n));

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
                    Console.WriteLine("{0} * {1} + {2} = {3} with factor {4:F}", m2, m1, rest, n, m2 / (double)m1);
                    break;
                }
            }

            return isProgressive;
        }

//        private static bool IsProgressive(long n)
//        {
//            bool isProgressive = false;
//            long upperMultiplier = (long)Math.Floor(Math.Sqrt(n));
//            long middle = upperMultiplier / 2;
//
//            for (long m1 = middle, mm1 = middle + 1; m1 >= 2 || mm1 <= upperMultiplier; m1--, mm1++)
//            {
//                long m2;
//                long rest;
//
//                if (m1 >= 2)
//                {
//                    m2 = n / m1;
//                    rest = n % m1;
//
//                    if (rest == 0)
//                    {
//                        continue;
//                    }
//
//                    isProgressive = Math.Abs(m2 / (double)m1 - m1 / (double)rest) < 1e-8;
//
//                    if (isProgressive)
//                    {
//                        Console.WriteLine("{0} * {1} + {2} = {3} with factor {4:F}", m2, m1, rest, n, m2 / (double)m1);
//                        break;
//                    }
//                }
//
//                if (mm1 <= upperMultiplier)
//                {
//                    m2 = n / mm1;
//                    rest = n % mm1;
//
//                    if (rest == 0)
//                    {
//                        continue;
//                    }
//
//                    isProgressive = Math.Abs(m2 / (double)mm1 - mm1 / (double)rest) < 1e-8;
//
//                    if (isProgressive)
//                    {
//                        Console.WriteLine("{0} * {1} + {2} = {3} with factor {4:F}", m2, mm1, rest, n, m2 / (double)mm1);
//                        break;
//                    }
//                }
//            }
//
//            return isProgressive;
//        }
    }
}
