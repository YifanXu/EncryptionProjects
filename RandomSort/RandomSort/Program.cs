using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(CheckSorted(new int[] { -1, 1, 2, 5, 6 }));
            Console.WriteLine(RandomSort(new int[] { 5, 1, 2}));
            Console.ReadLine();
        }

        public static long RandomSort(int[] nums)
        {
            long iteration = 0;
            Random r = new System.Random();
            while(true)
            {
                iteration++;
                int a = r.Next(nums.Length - 1);
                int b = r.Next(nums.Length - 1);
                int temp = nums[a];
                nums[a] = nums[b];
                nums[b] = temp;
                if (CheckSorted(nums)) return iteration;
            }
        }

        public static bool CheckSorted(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return true;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1]) return false;
            }
            return true;
        }
    }
}
