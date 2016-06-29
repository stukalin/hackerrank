namespace Hackerrank.WeekOfCode21
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    class LuckBalance
    {
        [TestCase(6, 3, "5 1 2 1 1 1 8 1 10 0 5 0", ExpectedResult = 29)]
        public int Solution(int n, int k, string input)
        {
            List<int> importants = new List<int>();
            int balance = 0;

            var inArr = input.Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < inArr.Length; i+=2)
            {
                if (inArr[i + 1] == 0)
                {
                    // we can lose
                    balance += inArr[i];
                }
                else
                {
                    importants.Add(inArr[i]);
                }
            }

            importants.Sort();

            balance -= importants.Take(importants.Count - k).Sum();
            balance += importants.Skip(importants.Count - k).Sum();

            return balance;            
        }
    }
}
