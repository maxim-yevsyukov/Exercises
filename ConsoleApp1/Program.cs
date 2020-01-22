using System;

namespace ConsoleApp1
{

    class Program
    {

        static void Main(string[] args)
        {
            long[] arr = { 3, 6, 2, 9, -1, 10};

            if (arr == null)
                Console.WriteLine("Empty");
            if (arr.Length == 0)
                Console.WriteLine("Empty");

            //var root = TreeNode(arr[0], true);

            long leftSum = 0, rightSum = 0;
            int i = 1, level = 1;
            while (i < arr.Length)
            {
                
                int curLevelCount = (int)Math.Pow(2, Convert.ToDouble(level));
                int halfCount = curLevelCount / 2;

                int j;
                for (j = i; j < i + halfCount; j++)
                    if (arr[j] > -1)
                        leftSum += arr[j];

                i = j;
                for (; j < i + halfCount && j < arr.Length; j++)
                    if (arr[j] > -1)
                        rightSum += arr[j];
                i = j;
                level++;
            }

            if (leftSum > rightSum)
                Console.WriteLine("Left");
            else if (rightSum > leftSum)
                Console.WriteLine("Right");
            else Console.WriteLine("Equal");

            Console.ReadLine();
        }
    }
}
