using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KataSolutions.BecomeImmortal
{
    // TODO - figure out how to optimize this to pass the test with a HUGE array!
    public class BecomeImmortalKata
    {
        /// set true to enable debug
        public static bool Debug = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">Rectangle dimension</param>
        /// <param name="m">Rectangle dimension</param>
        /// <param name="loss">Transmission loss in seconds</param>
        /// <param name="timeLimit">Time in seconds, after which to wrap around to 0 seconds and begin counting again</param>
        /// <returns></returns>
        public static long ElderAge(long n, long m, long loss, long timeLimit)
        {
            long eldersTime = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        long xor = i ^ j;
            //        if (xor > loss)
            //        {
            //            eldersTime += xor - loss;
            //            //eldersTime = AddTimeToElder(eldersTime, timeLimit, (xor - loss));
            //        }
            //    }
            //}


            long largerAxis = n > m ? n : m;
            long smallerAxis = n > m ? m : n;
            long Task1EldersTime = 0;

            long xor;

            BigInteger numElements = BigInteger.Multiply(BigInteger.Parse(n.ToString()),
                                     BigInteger.Parse(m.ToString()));
            var qwe = 0;
            for (int i = 0; i < smallerAxis; i++)
            {
                qwe = i;
            }

            for (long i = smallerAxis; i < largerAxis; i++)
            {
                for (int j = 0; j < smallerAxis; j++)
                {
                    xor = i ^ j;
                    if (xor > loss)
                    {
                        //eldersTime += xor - loss;
                        eldersTime = AddTimeToElder(eldersTime, timeLimit, (xor - loss));

                    }
                }
            }
       
            for (int i = 0; i < smallerAxis; i++)
            {
                int j = i;
                while (j < smallerAxis)
                {
                    xor = i ^ j;
                    if (xor > loss)
                    {
                        //eldersTime += xor - loss;
                        Task1EldersTime = AddTimeToElder(Task1EldersTime, timeLimit, (xor - loss));
                    }
                    j++;
                }

            }
            Task1EldersTime = AddTimeToElder(Task1EldersTime, timeLimit, Task1EldersTime);
            //eldersTime *= 2;            


            eldersTime = AddTimeToElder(eldersTime, timeLimit, Task1EldersTime);



            eldersTime = eldersTime % (timeLimit);
            return eldersTime; // do it!

        }


        private static long AddTimeToElder(long eldersTime, long timeLimit, long timeToAdd)
        {
            long output = eldersTime + timeToAdd;
            if (output > timeLimit)
            {
                output = output % timeLimit;
            }

            return output;
        }

    }
}
