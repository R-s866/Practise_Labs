using System;
using System.Collections.Generic;

// 15.53
namespace Lab_008_TDD_Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = ArrayListDictionarySnapLab.
                GetSnapLabTotal(6, 4, 3, 1, 2);
            Console.WriteLine(i);
        }
    }
    public class ArrayListDictionarySnapLab
    {
        public static int GetSnapLabTotal
            (int a, int b, int c, int d, int e)
        {
            int[] nums = new int[]{
                a , b, c, d, e
            };

            int[] outNums = new int[5];
            for (int i = 0; i < nums.Length; i++)
            {
                int o = nums[i] + 5;
                outNums[i] = o;
            }

            List<int> n = new List<int>();
            foreach(int p in outNums)
            {
                int o = p * p;
                n.Add(o);
            }

            int count = 0;
            Dictionary<int, int> k = new Dictionary<int, int>();
            foreach(int h in n)
            {
                int o = h - 10;
                k.Add(count, o);
                count++;
            }

            int sum = 0;
            foreach(KeyValuePair<int,int> s in k)
            {
                sum += s.Value;
            }

            return sum;
        }
    }
}
