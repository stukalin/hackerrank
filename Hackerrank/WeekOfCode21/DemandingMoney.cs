using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank.WeekOfCode21
{
    [TestFixture]
    class DemandingMoney
    {
        private int maxMoney;
        private List<List<int>> usedPaths;

        [Test]
        public void Test1()
        {
            var result = Solution(3, 2, new[] { 6, 8, 2 }, new[,] { { 1, 2 }, { 3, 2 } });
            Console.WriteLine(result);
        }


        public string Solution(int n, int m, int[] cs, int[,] abs)
        {
            maxMoney = 0;
            usedPaths = new List<List<int>>();

            char[,] paths = new char[n, n];
            for (int i=0;i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    paths[i, j] = '0';
                }

                paths[i, i] = '1';
            }

            for (int i=0;)
        }

        pu
    }
}
