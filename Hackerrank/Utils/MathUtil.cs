namespace Hackerrank.Utils
{
    using System;
    using System.Collections.Generic;

    public static class MathUtil
    {
        public static IEnumerable<Tuple<long, long>> PerfectSquaresUpTo(long upperborder)
        {
            long prevsquare = 1;
            long prevsquareroot = 1;

            while (prevsquare <= upperborder)
            {
                prevsquareroot++;
                prevsquare = prevsquare + 2 * prevsquareroot - 1;

                yield return Tuple.Create(prevsquareroot, prevsquare);
            }
        }

        public static IEnumerable<Tuple<long, long>> PerfectSquaresFrom(long upperborderroot)
        {
            long prevsquare = upperborderroot * upperborderroot;
            long prevsquareroot = upperborderroot;

            while (prevsquare > 1)
            {
                yield return Tuple.Create(prevsquareroot, prevsquare);

                prevsquare = prevsquare - 2 * prevsquareroot + 1;
                prevsquareroot--;
            }
        }

        public static bool IsPerfectSquare(long input)
        {
            long closestRoot = (long)Math.Sqrt(input);
            return input == closestRoot * closestRoot;
        }

        public static long LastFibUpto(long n)
        {
            long a = 1, b = 1;
            while (a < n)
            {
                a = a + b;
                b = a - b;
            }

            return b;
        }

        public static IEnumerable<long> FibUpto(long n)
        {
            long a = 1, b = 1;
            while (a < n)
            {
                a = a + b;
                b = a - b;

                yield return b;
            }
        }

        public static long Factorial(int n)
        {            
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
