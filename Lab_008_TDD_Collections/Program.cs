using System;
using System.Collections.Generic;

// 15.53
namespace Lab_008_TDD_Collections
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    // Class to contain Speed Lab
    public class ArrayListDictionarySnapLab
    {
        // Method that take 5 int params
        public static int GetSnapLabTotal
            (int a, int b, int c, int d, int e)
        {
            // Put int params into an array
            int[] nums = new int[]{
                a , b, c, d, e
            };

            // Loop through array and add 5 to each int value and add to new array
            int[] outNums = new int[5];
            for (int i = 0; i < nums.Length; i++)
            {
                int o = nums[i] + 5;
                outNums[i] = o;
            }

            // Loop through array, square the int value and add to a list
            List<int> n = new List<int>();
            foreach(int p in outNums)
            {
                int o = p * p;
                n.Add(o);
            }

            // Loop through list, -10 from int value and add to Dictionary
            int count = 0;
            Dictionary<int, int> k = new Dictionary<int, int>();
            foreach(int h in n)
            {
                int o = h - 10;
                k.Add(count, o);
                count++;
            }

            // Loop through Dictionary and sum the int values
            int sum = 0;
            foreach(KeyValuePair<int,int> s in k)
            {
                sum += s.Value;
            }

            // Return sum values of the dictionary
            return sum;
        }
    }
}
