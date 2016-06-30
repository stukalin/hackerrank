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
//            var result = Solution(5, 6, new[] { 100,1,1,1,1 }, new[,] { { 1, 2 }, { 1, 3 }, {1,4}, {1,5},{2,4},{3,4} });
//            Console.WriteLine(result);
//            Assert.That(result, Is.EqualTo("100 1"));

            var result = Solution(5, 6, new[] { 0, 0, 0, 0, 0 }, new[,] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 2, 4 }, { 3, 4 } });
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo("100 1"));
        }

        public string Solution(int n, int m, int[] cs, int[,] abs)
        {
            maxMoney = 0;
            usedPaths = new List<List<int>>();
            this.moneys = cs;

            char[,] paths = new char[n, n];
            for (int i=0;i<n;i++)
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

            for (int i=0;i<n;i++)
            {
                Step(i, 0, new List<int>(), paths);
            }

            return string.Format("{0} {1}", this.maxMoney, this.usedPaths.Count);
        }

        public void Step(int row, int sum, List<int> curpath, char[,] paths)
        {
            // add the sum 
            sum += this.moneys[row];
            curpath.Add(row);

            // set visited in corresponding column
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                if (paths[i, row] == '0')
                {
                    paths[i, row] = 'v';
                }
            }

            for (int j = 0; j < paths.GetLength(0); j++)
            {
                if (paths[row, j] == '0')
                {
                    paths[row, j] = 'v';

                    // set visited in column to be visited
                    for (int i = 0; i < paths.GetLength(0); i++)
                    {
                        if (paths[i,j] == '0')
                        {
                            paths[i, j] = 'v';
                        }
                    }

                    // make a step
                    Step(j, sum, curpath, paths);

                    // rollback
                    paths[row, j] = '0';

                    for (int i = 0; i < paths.GetLength(0); i++)
                    {
                        if (paths[i, j] == 'v')
                        {
                            paths[i, j] = '0';
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", curpath));

            if (sum > this.maxMoney)
            {
                this.maxMoney = sum;
                this.usedPaths.Clear();
                this.usedPaths.Add(curpath.ToList());

                //Console.WriteLine(string.Join(" ", curpath));

            }
            else if (sum == this.maxMoney)
            {
                if (usedPaths.All(a => a.Except(curpath).Any()))
                {
                    this.usedPaths.Add(curpath.ToList());

                    //Console.WriteLine(string.Join(" ", curpath));

                }
            }

            // rollback
            curpath.Remove(row);

            // set visited in corresponding column
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                if (paths[i, row] == 'v')
                {
                    paths[i, row] = '0';
                }
            }
        }
    }
}
