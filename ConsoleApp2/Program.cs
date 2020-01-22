using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ConsoleApp2
{
    class Program
    {
        static int CharSetSize = 256;

        static bool isPalindrommable(string str)
        {

            int[] charsetCount = new int[CharSetSize];
            for (int i = 0; i < charsetCount.Length; i++)
                charsetCount[i] = 0;

            for (int i = 0; i < str.Length; i++)
                charsetCount[(int)(str[i])]++;

            int oddCount = 0;
            for (int i = 0; i < CharSetSize; i++)
            {
                if ((charsetCount[i] & 1) == 1)
                    oddCount++;

                if (oddCount > 1)
                    return false;
            }

            return true;
        }
        static string balanceAnglesRec(string angles, string finalResult)
        {
            if (String.IsNullOrEmpty(angles))
                return finalResult;

            if (angles[0] == '>')
            {
                angles = '<' + angles;
                finalResult = '<' + finalResult;
            }

            if (angles[angles.Length - 1] == '<')
            {
                angles = angles + '>';
                finalResult = finalResult + '>';
            }


            return balanceAnglesRec(angles.Replace("<>", ""), finalResult);
        }
        static string balanceAngles(string angles)
        {
            //if (angles == null || angles.Length == 0)
            //    return "";

            //if (angles[0] == '>')
            //    return '<' + angles;

           

            string copy = angles;
            copy = copy.Replace("<>", "");

            

            //for(int i = 0; i<copy.Length; i++)
            //{

            //}


            string ret = "";
            return ret;
        }

        //static void Main(string[] args)
        //{

        //    //string s = "><<><";
        //    //string copyForResult = s;
        //    //var finalResult = balanceAnglesRec(s, copyForResult);
        //    //Console.WriteLine(finalResult);
        //    //Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            while (true)
            {
                int[] mHeights = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    mHeights[i] = int.Parse(Console.ReadLine()); // represents the height of one mountain.

                }

                //Array.Sort(mHeights);
                Console.WriteLine(mHeights[7]); // The index of the mountain to fire on.

            }


            Console.ReadLine();
        }
    }
}
