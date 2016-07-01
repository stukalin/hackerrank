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

        //private SortedSet<string> usedPaths;
        private SortedDictionary<string, string> usedPaths;

        private int[] moneys;

        [Test]
        public void Test1()
        {
            var result = Solution(3, 2, new[] { 6, 8, 2 }, new[,] { { 1, 2 }, { 3, 2 } });
            Assert.That(result, Is.EqualTo("8 2"));
        }

        [Test]
        public void Test2()
        {
            var result = Solution(5, 6, new[] { 100, 1, 1, 1, 1 }, new[,] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 2, 4 }, { 3, 4 } });
            Assert.That(result, Is.EqualTo("100 1"));

            result = Solution(5, 6, new[] { 0, 0, 0, 0, 0 }, new[,] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 2, 4 }, { 3, 4 } });
            Assert.That(result, Is.EqualTo("0 10"));
        }

        [Test]
        public void Test3()
        {
            var result = Solution(34, 0, Enumerable.Repeat(0, 34).ToArray(), new int[0,0]);
            //var result = Solution(9, 0, Enumerable.Repeat(0, 9).ToArray(), new int[0,0]);
            Console.WriteLine(result);
            //Assert.That(result, Is.EqualTo("8 2"));
        }

        public string Solution(int n, int m, int[] cs, int[,] abs)
        {
            maxMoney = 0;
            usedPaths = new SortedDictionary<string, string>();
            //usedPaths = new SortedSet<string>();
            moneys = cs;

            char[,] paths = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    paths[i, j] = '0';
                }

                paths[i, i] = '1';
            }

            for (int i = 0; i < abs.GetLength(0); i++)
            {
                paths[abs[i, 0] - 1, abs[i, 1] - 1] = '1';
                paths[abs[i, 1] - 1, abs[i, 0] - 1] = '1';
            }

            for (int i = 0; i < n; i++)
            {
                Step(i, 0, new List<int>(), paths, new int[n]);
            }

            return string.Format("{0} {1}", maxMoney, usedPaths.Count);
        }

        public void Step(int row, int sum, List<int> curpath, char[,] paths, int[] forbidden)
        {
            // add the sum 
            sum += moneys[row];
            curpath.Add(row);

            // set visited in corresponding column
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                if (paths[row, i] == '1')
                {
                    forbidden[i]++;
                }
            }

            for (int j = 0; j < paths.GetLength(0); j++)
            {
                if (paths[row, j] == '0' && forbidden[j] == 0)
                {
                    if (sum + this.moneys[row] >= this.maxMoney)
                    {
                        // make a step
                        Step(j, sum, curpath, paths, forbidden);
                    }
                }
            }

            var key = string.Join(",", curpath);
            if (sum > maxMoney)
            {
                maxMoney = sum;
                usedPaths.Clear();
                usedPaths.Add(key, key);
            }
            else if (sum == maxMoney)
            {
                usedPaths.Add(key, key);
//                if (usedPaths.All(a => a.Except(curpath).Any()))
//                {
//                    usedPaths.Add(curpath.ToList());
//                }
            }

            // rollback
            curpath.Remove(row);

            // set visited in corresponding column
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                if (paths[row, i] == '1')
                {
                    forbidden[i]--;
                }
            }
        }
    }
}
