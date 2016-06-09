namespace Hackerrank.Projecteuler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Hackerrank.Utils;

    using NUnit.Framework;
    using NUnit.Framework.Compatibility;

    [TestFixture]
    class ProjectEuler142 : BaseTest
    {
        [Test]
        public void HowManyAreThere()
        {
            Console.WriteLine(MathUtil.PerfectSquaresUpTo(1000000000000L).Count());
        }

        [TestCase(1)]
        public void LetsTry(int casesNeeded)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SortedDictionary<long, long> values = new SortedDictionary<long, long>();

            long upperborder = 100L;

            // todo this should be 10^12 
            foreach (var tuple in MathUtil.PerfectSquaresUpTo(upperborder))
            {
                long root = tuple.Item1;
                long addition = 0L;
                // find how much we need to add for the next square
                long x = 0;

                Log.InfoFormat("for the root {0}", root);

                // todo this should be 10^12
                while (x <= upperborder)
                {
                    addition += 4 * root + 4;
                    long y = addition / 2;
                    x = tuple.Item2 + y;

                    if (x > upperborder)
                    {
                        break;
                    }

                    Log.InfoFormat("found a couple {0} - {1} with addition {2}", x, y, addition);
                    root += 2;

                    Assert.That(MathUtil.IsPerfectSquare(x+y), Is.True);
                    Assert.That(MathUtil.IsPerfectSquare(x-y), Is.True);

                    long z;
                    if (values.ContainsKey(y))
                    {
                        z = values[y];
                        Log.InfoFormat("Probable triple by y: {0}, {1}, {2}", x, y, z);

                        if (MathUtil.IsPerfectSquare(x + z) && MathUtil.IsPerfectSquare(x - z))
                        {
                            if (z > y)
                            {
                                var t = z;
                                z = y;
                                y = t;
                            }

                            
                            Assert.That(new[] { x, y, z }, Is.Ordered.Descending);

                        
                            Console.WriteLine("");
                            Console.WriteLine("!!!! {0}, {1}, {2}", x, y, z);
                            Console.WriteLine("");

                            Assert.That(MathUtil.IsPerfectSquare(x + y), Is.True, "x + y {0}", x + y);
                            Assert.That(MathUtil.IsPerfectSquare(x - y), Is.True, "x - y {0}", x - y);
                            Assert.That(MathUtil.IsPerfectSquare(x + z), Is.True, "x + z {0}", x + z);
                            Assert.That(MathUtil.IsPerfectSquare(x - z), Is.True, "x - z {0}", x - z);
                            Assert.That(MathUtil.IsPerfectSquare(y + z), Is.True, "y + z {0}", y + z);
                            Assert.That(MathUtil.IsPerfectSquare(y - z), Is.True, "y - z {0}", y - z);
                        }
                    }
                    else
                    {
                        values.Add(y, x);
                    }

                    if (values.ContainsKey(x))
                    {
                        z = values[x];
                        Log.InfoFormat("Probable triple by x: {0}, {1}, {2}", z, x, y);
                        if (MathUtil.IsPerfectSquare(y + z) && MathUtil.IsPerfectSquare(y - z))
                        {
                            if (x > z)
                            {
                                var t = z;
                                z = x;
                                x = t;
                            }

                            //Assert.That(new[] { z, x, y }, Is.Ordered.Descending);

                        
                            Console.WriteLine("");
                            Console.WriteLine("!!!! {0}, {1}, {2}", z, x, y);
                            Console.WriteLine("");

                            Assert.That(MathUtil.IsPerfectSquare(z + x), Is.True);
                            Assert.That(MathUtil.IsPerfectSquare(z - x), Is.True);
                            Assert.That(MathUtil.IsPerfectSquare(z + y), Is.True);
                            Assert.That(MathUtil.IsPerfectSquare(z - y), Is.True);
                            Assert.That(MathUtil.IsPerfectSquare(x + y), Is.True);
                            Assert.That(MathUtil.IsPerfectSquare(x - y), Is.True);
                        }
                    }
                    else
                    {
                        values.Add(x, y);
                    }
                }
            }

            sw.Stop();
            Log.InfoFormat("{0}ms passed", sw.ElapsedMilliseconds);
        }
    }
}
