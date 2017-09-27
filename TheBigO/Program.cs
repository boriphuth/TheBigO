using System;
using System.Diagnostics;

namespace TheBigO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[20000];
            AddRandomNumbers(testArray);

            //O(1)
            PerformSomeAction_O1(testArray);

            //O(n)
            PerformSomeAction_On(testArray);

            //O(n^2)
            PerformSomeAction_On2(testArray);

            //O(log n)
            PerformSomeAction_On(testArray); //assume array sorted
            PerformSomeAction_Ologn(testArray);


            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private static void AddRandomNumbers(int[] testArray)
        {
            Random random = new Random();
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = random.Next();
            }
        }

        private static void PerformSomeAction_O1(int[] testArray)
        {
            //O(1)
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int loopCount = 0;
            testArray[0] = 1;
            loopCount++;
            sw.Stop();
            Console.WriteLine("O(1) complete in {0} Elapsed={1}", loopCount, sw.Elapsed);
        }

        private static void PerformSomeAction_On(int[] testArray)
        {
            //O(n)
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int loopCount = 0;
            for (int i = 0; i < testArray.Length; i++)
            {
                loopCount++;
                testArray[i] = i;
            }
            sw.Stop();
            Console.WriteLine("O(n) complete in {0} Elapsed={1}", loopCount, sw.Elapsed);
        }

        private static void PerformSomeAction_On2(int[] testArray)
        {
            //O(n^2)
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int loopCount = 0;
            for (int i = 0; i < testArray.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    loopCount++;
                }
            }
            sw.Stop();
            Console.WriteLine("O(n^2) complete in {0} Elapsed={1}", loopCount, sw.Elapsed);
        }

        private static void PerformSomeAction_Ologn(int[] testArray)
        {
            //O(log n)
            // 2^x = n
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int loopCount = 0;
            Random random  = new Random();
            int NumberToFInd = random.Next(0, testArray.Length);
            int Upper = testArray.Length - 1;
            int Lower = 0;
            int indexi = (int) Math.Floor(Upper / 2.0);
            while (NumberToFInd != testArray[indexi])
            {
                loopCount++;
                if (NumberToFInd < testArray[indexi])
                {
                    Upper = indexi;
                    indexi = Lower + (int) Math.Floor((Upper - Lower) / 2.0);
                }
                else
                {
                    Lower = indexi;
                    indexi = Lower + (int)Math.Floor((Upper - Lower) / 2.0);
                }
            }
            sw.Stop();
            Console.WriteLine("O(log n)) complete in {0} Elapsed={1}", loopCount, sw.Elapsed);
        }
    }
}
