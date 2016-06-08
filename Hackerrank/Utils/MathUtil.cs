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
    }
}
