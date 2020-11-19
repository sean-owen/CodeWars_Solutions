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
            long xor = 0;
            long largerAxis = n > m ? n : m;
            long smallerAxis = n > m ? m : n;

            //for (long i = loss+1; i < n; i++)
            //{
            //    for (long j = 0; j < m; j++)
            //    {
            //        xor = i ^ j;
            //        if (xor > loss)
            //        {

            //            eldersTime += xor - loss;
            //            //eldersTime = AddTimeToElder(eldersTime, timeLimit, (xor - loss));
            //        }
            //    }
            //}

            //for (long i = 0; i < loss+1; i++)
            //{
            //    for (long j = loss+1; j < m; j++)
            //    {
            //        xor = i ^ j;
            //        if (xor > loss)
            //        {

            //            eldersTime += xor - loss;
            //            //eldersTime = AddTimeToElder(eldersTime, timeLimit, (xor - loss));
            //        }
            //    }
            //}


            //////////////////////////////////////////////////////////////////////////////////////////////////////// end naive soln

            // calculate every other line (pairs)
            // reduce data set based on smaller than loss






            //long Task1EldersTime = 0;

            //for (long x = 0; x < smallerAxis; x++)
            //{
            //    long y = x;
            //    while (y < smallerAxis)
            //    {
            //        xor = x ^ y;
            //        if (xor > loss)
            //        {
            //            //eldersTime += xor - loss;
            //            Task1EldersTime = AddTimeToElder(Task1EldersTime, timeLimit, (long)(xor - loss));
            //        }
            //        y++;
            //    }

            //}
            //Task1EldersTime = AddTimeToElder(Task1EldersTime, timeLimit, Task1EldersTime);


            //for (long i = smallerAxis; i < largerAxis; i++)
            //{
            //    for (long j = 0; j < smallerAxis; j++)
            //    {
            //        xor = i ^ j;
            //        if (xor > loss)
            //        {
            //            //eldersTime += xor - loss;
            //            eldersTime = AddTimeToElder(eldersTime, timeLimit, (long)(xor - loss));

            //        }
            //    }
            //}

            ////eldersTime *= 2;            


            //eldersTime = AddTimeToElder(eldersTime, timeLimit, Task1EldersTime);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// end second pass soln
            long y;


            // if row is even and row+1 < smallerAxis

            // if even number of columns
            // row + 1 = current row summations

            // if odd number of columns
            // row + 1 = current row summation + 1



            // each line is an arithmetic series where
            // sum = [number of terms * (first term + last term)] / 2
            if ((n % 2 != 0) && (m % 2 != 0))
            {
                BigInteger nBig = BigInteger.Parse(n.ToString());
                BigInteger mBig = BigInteger.Parse(m.ToString());

                BigInteger numTerms = n - (loss + 1);




                BigInteger arithmeticSeriesSum = (numTerms * (1 + numTerms)) / 2;


                BigInteger testTime = m * arithmeticSeriesSum;


                var additionalSum = ((m - 1) * (1 + (m - 1))) / 2;

                testTime += additionalSum;

                testTime = testTime % (timeLimit);

                return (long)testTime;
            }
            else
            {
                BigInteger nBig = BigInteger.Parse(n.ToString());
                BigInteger mBig = BigInteger.Parse(m.ToString());

                BigInteger numTerms = n - (loss + 1);

                BigInteger arithmeticSeriesSum = (numTerms * (1 + numTerms)) / 2;

                BigInteger testTime = m * arithmeticSeriesSum;
                testTime = testTime % (timeLimit);

                return (long)testTime;
            }

            //long numTerms = n - (loss + 1);

            //long arithmeticSeriesSum = (numTerms * (1 + numTerms)) / 2;

            //eldersTime = m * arithmeticSeriesSum;

            //eldersTime = eldersTime % (timeLimit);


            //y = 0;
            //long rowStart = loss + 1;
            //while (y < smallerAxis)
            //{
            //    if (y == rowStart)
            //    {
            //        rowStart += loss + 1;
            //    }


            //    for (long x = rowStart; x < smallerAxis; x++)
            //    {
            //        xor = x ^ y;
            //        var test = xor - loss;
            //        if (xor > loss)
            //        {
            //            //eldersTime += xor - loss;
            //            eldersTime = AddTimeToElder(eldersTime, timeLimit, (long)(xor - loss));
            //        }
            //    }

            //    y++;
            //}
            //eldersTime *= 2;



            //for (long x = smallerAxis; x < largerAxis; x++)
            //{
            //    for (y = 0; y < smallerAxis; y++)
            //    {
            //        xor = x ^ y;
            //        if (xor > loss)
            //        {
            //            //eldersTime += xor - loss;
            //            eldersTime = AddTimeToElder(eldersTime, timeLimit, (long)(xor - loss));

            //        }
            //    }
            //}



            //eldersTime = eldersTime % (timeLimit);
            //return eldersTime; // do it!

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
