namespace Hackerrank.Projecteuler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Hackerrank.Utils;

    using NUnit.Framework;

    [TestFixture]
    class ProjectEuler142
    {
        [Test]
        public void HowManyAreThere()
        {
            Console.WriteLine(MathUtil.PerfectSquaresUpTo(1000000000000L).Count());
        }

        [TestCase(1)]
        public void LetsTry(int casesNeeded)
        {
            SortedList<long, long> values = new SortedList<long, long>();

            foreach (var tuple in MathUtil.PerfectSquaresUpTo(100000000))
            {
                //Console.WriteLine("For {0}^2 = {1}", tuple.Item1, tuple.Item2);

                long root = tuple.Item1;
                long addition = 0L;
                // find how much we need to add for the next square
                while (addition < 1000000)
                {
                    addition += 2 * (root + 1) + 2 * (root + 2) - 2;
                    long next2ndsquare = tuple.Item2 + addition;

                    long y = addition / 2;
                    long x = next2ndsquare - y;

                    //Console.WriteLine("found a couple {0} - {1}", x, y);
                    root += 2;

                    //Assert.That(MathUtil.IsPerfectSquare(x+y), Is.True);
                    //Assert.That(MathUtil.IsPerfectSquare(x-y), Is.True);

                    long z;
                    if (values.ContainsKey(y))
                    {
                        z = values[y];
                        //Console.WriteLine("Probable triple by y: {0}, {1}, {2}", x, y, z);

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
                        //Console.WriteLine("Probable triple by x: {0}, {1}, {2}", z, x, y);
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
        }
    }
}
