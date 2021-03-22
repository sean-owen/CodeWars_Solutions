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
        public static long ElderAge(long x, long y, long loss, long timeLimit)
        {
            return MagicRectangle.CalculateElderAge(x, y, loss, timeLimit);

            // TODO - make sure the x value is bigger...?
            long largerAxis = x > y ? x : y;
            long smallerAxis = x > y ? y : x;

            x = largerAxis;
            y = smallerAxis;

            var firstXValue = 1;
            do
            {
                firstXValue *= 2;
            } while (firstXValue <= x);
            firstXValue /= 2;

            var firstYValue = 1;
            do
            {
                firstYValue *= 2;
            } while (firstYValue <= y);
            firstYValue /= 2;


            // calculate values for the square y * y (because y is the smaller square)
            BigInteger sumFirstSquare = AriSum(firstYValue, firstYValue, loss);


            // calculate remaining rows firstYValue -> y

            // aSum each row should be aSum from firstYValue to (2 * firstYValue) - 1
            // multiply that aSum by y - firstYValue
            BigInteger numTerms = firstYValue;
            BigInteger a = (2 * firstYValue) - 1;
            BigInteger aSum = (numTerms * (firstYValue - loss + a - loss)) / 2;
            BigInteger aSumRemainingRows = aSum * (y - firstYValue);

            // ----- dealing with loss
            if (firstYValue > loss)
            {
                // then above eqns are good to go
            }
            else if ((firstYValue < loss) && (a > loss))
            {
                numTerms = a - loss;
                aSum = (numTerms * (loss + 1 + a)) / 2; // TODO should be a - loss? but then what if a - loss becomes lower than loss? 
                aSumRemainingRows = aSum * (y - firstYValue);
            }
            else
            {
                aSumRemainingRows = 0;
            }


            // Use to DEBUG if remaining row eqns are correct -------------- 
            //BigInteger remainingRowXors = 0;
            //for (var i = 0; i < firstYValue; i++)
            //{
            //    for (var j = firstYValue; j < y; j++)
            //    {
            //        var xor = i ^ j;
            //        if (xor > loss)
            //        {
            //            remainingRowXors += xor - loss;
            //        }
            //    }
            //}
            //aSumRemainingRows = remainingRowXors;
            // -----------------------------------------------------------------------




            // calculate remaining columns from firstYValue -> x

            // aSum each column should be aSum from firstYValue -> (2 * firstYValue) - 1
            // multiply that aSum by x - firstYValue
            numTerms = x - firstYValue;
            aSum = (numTerms * (firstYValue - loss + x - 1 - loss)) / 2;

            // ----- dealing with loss
            if (firstYValue > loss)
            {
                // then above eqns are good to go
            }
            else if ((firstYValue < loss) && ((x - 1) > loss))
            {
                numTerms = (x - 1) - loss;
                //aSum = (numTerms * (loss + 1 + (x - 1))) / 2; // TODO should be (x - 1) - loss? but then what if (x - 1) - loss becomes lower than loss?
                aSum = (numTerms * (1 + (x - 1) - loss)) / 2; // believe this is the way to deal with this scenario
            }
            else
            {
                aSum = 0;
            }


            BigInteger aSumRemainingColumns = 0;
            if (firstXValue == x) // x is multiple 2^n
            {
                aSumRemainingColumns = aSum * firstYValue;
            }
            else if (x % 2 != 0) // x is odd
            {
                aSumRemainingColumns = aSum * firstYValue;


                // +1 each row incrementing, up to row number #, where # = largest multiple of 2^n that divides x+1 or x-1 to give a whole number
                // after row number #, the increment jumps to ((# - 1) ^ 2) + # and then increments +1 each row up to row number 2 * #
                // after row number 2 * #, the increment jumps to 2 * ((# - 1) ^ 2) + increment value at row 2 * #
                // and so on, each # rows, incrementing by (row / #) * (# - 1)^2 + last increment value

                BigInteger rowOnWhichIncrementSquares = 0;
                BigInteger iterator = 1;
                while (iterator <= x + 1)
                {
                    iterator *= 2;
                    if ((x - 1) % iterator == 0 && iterator > rowOnWhichIncrementSquares)
                    {
                        rowOnWhichIncrementSquares = iterator;
                    }
                    if ((x + 1) % iterator == 0 && iterator > rowOnWhichIncrementSquares)
                    {
                        rowOnWhichIncrementSquares = iterator;
                    }
                }


                numTerms = firstYValue - 1;
                if (numTerms < rowOnWhichIncrementSquares)
                {
                    // ----- dealing with loss
                    if (1 > loss)
                    {
                        aSumRemainingColumns += (numTerms * (1 + firstYValue - 1)) / 2;
                    }
                    //else if ((1 < loss) && ((firstYValue - 1) > loss))
                    //{
                    //    //aSumRemainingColumns += ((numTerms - loss) * (loss + firstYValue - 1)) / 2; // TODO should be (firstYValue - 1) - loss? but then what if (firstYValue - 1) - loss becomes lower than loss? 
                    //    aSumRemainingColumns += ((numTerms - loss) * (1 + firstYValue - 1 - loss)) / 2; // believe this is the way to deal with this scenario
                    //}
                    else
                    {
                        aSumRemainingColumns += ((numTerms) * (1 + firstYValue - 1)) / 2; // believe this is the way to deal with this scenario
                    }
                }
                else
                {
                    //aSumRemainingColumns += (numTerms * (1 + firstYValue - 1)) / 2; // +1 from first term to last term
                    //aSumRemainingColumns -= numTerms / rowOnWhichIncrementSquares; // dont get +1 at the row change where the square is added, so remove 1 for each change
                    //aSumRemainingColumns += (rowOnWhichIncrementSquares - 1) * (rowOnWhichIncrementSquares - 1) * (numTerms / rowOnWhichIncrementSquares);

                    // aSum from row 0 -> rowOnWhichIncrementSquares
                    BigInteger nestedNumTerms = rowOnWhichIncrementSquares - 1;

                    // ----- dealing with loss
                    BigInteger firstSeries = 0;
                    if (1 > loss)
                    {
                        firstSeries = (nestedNumTerms * (1 + nestedNumTerms)) / 2;
                        aSumRemainingColumns += firstSeries;
                    }
                    //else if ((1 < loss) && (nestedNumTerms > loss))
                    //{
                    //    //firstSeries = ((nestedNumTerms - loss) * (loss + nestedNumTerms)) / 2; // TODO should be (nestedNumTerms) - loss? but then what if (nestedNumTerms) - loss becomes lower than loss? 
                    //    firstSeries = ((nestedNumTerms - loss) * (1 + nestedNumTerms - loss)) / 2; // believe this is the way to deal with this scenario (maybe missing nestedNumTerms - loss)                        
                    //    aSumRemainingColumns += firstSeries;
                    //}
                    else
                    {
                        firstSeries = ((nestedNumTerms) * (1 + nestedNumTerms)) / 2; // believe this is the way to deal with this scenario (maybe missing nestedNumTerms - loss)                        
                        aSumRemainingColumns += firstSeries;
                    }


                    BigInteger firstIncVal = (rowOnWhichIncrementSquares - 1); // 3
                    BigInteger firstIncrement = (rowOnWhichIncrementSquares - 1) * (rowOnWhichIncrementSquares - 1); // 9
                    // aSumRemainingColumns += firstIncrement;

                    BigInteger subsequentIncrements = firstIncVal + firstIncrement; // 12
                    BigInteger finalIncValue = 0;
                    int i = 1;
                    while (i < ((numTerms + 1) / rowOnWhichIncrementSquares)) // the division that gives how many times we jump by increment as a whole number
                    {
                        finalIncValue = i * subsequentIncrements;

                        // ----- dealing with loss
                        if (finalIncValue > loss)
                        {
                            aSumRemainingColumns += (finalIncValue) * rowOnWhichIncrementSquares;
                            aSumRemainingColumns += firstSeries; // TODO - not sure if this should be inside this if statement
                        }

                        i++;
                    }

                    // this condition should technically never be entered...?
                    if ((numTerms + 1) % rowOnWhichIncrementSquares != 0)
                    {
                        // ----- dealing with loss
                        if ((finalIncValue + subsequentIncrements) > loss)
                        {
                            aSumRemainingColumns += ((finalIncValue + subsequentIncrements) - loss) * (numTerms % rowOnWhichIncrementSquares);
                        }
                        if (((numTerms % rowOnWhichIncrementSquares) - 1) > loss)
                        {
                            aSumRemainingColumns += (numTerms % rowOnWhichIncrementSquares) - 1 - loss;
                        }

                        // ----- dealing with loss
                        if (1 > loss)
                        {
                            nestedNumTerms = (numTerms % rowOnWhichIncrementSquares) - 1;
                            BigInteger lastSeries = (nestedNumTerms * (1 + nestedNumTerms)) / 2;
                            aSumRemainingColumns += lastSeries;
                        }
                        //else if ((1 < loss) && (nestedNumTerms > loss))
                        //{
                        //    nestedNumTerms = (numTerms % rowOnWhichIncrementSquares) - 1;
                        //    //BigInteger lastSeries = ((nestedNumTerms - loss) * (loss + nestedNumTerms)) / 2; // TODO should be (nestedNumTerms) - loss? but then what if (nestedNumTerms) - loss becomes lower than loss? 
                        //    BigInteger lastSeries = ((nestedNumTerms - loss) * (1 + nestedNumTerms - loss)) / 2; // believe this is the way to deal with this scenario (maybe missing a -1 as indicated in line above)                            
                        //    aSumRemainingColumns += lastSeries;
                        //}
                        else
                        {
                            // dont add anything 
                            nestedNumTerms = (numTerms % rowOnWhichIncrementSquares) - 1;
                            BigInteger lastSeries = ((nestedNumTerms - loss) * (1 + nestedNumTerms - loss)) / 2; // believe this is the way to deal with this scenario (maybe missing a -1 as indicated in line above)                            
                            aSumRemainingColumns += lastSeries;
                        }

                    }

                }


            }
            else // x is even
            {
                aSumRemainingColumns = aSum * firstYValue;

                // check if rows is > rows required for a pattern change --------

                // get largest multiple 2^n that divides x to give a whole number
                BigInteger rowOfPatternChange = 0;
                BigInteger multiple2PowN = 1;
                while (multiple2PowN < x)
                {
                    if (x % multiple2PowN == 0)
                    {
                        rowOfPatternChange = multiple2PowN;
                    }
                    multiple2PowN *= 2;
                }


                if (firstYValue > rowOfPatternChange)
                {
                    // +4, +4 each 2 rows (not including first 2 rows) --- need to update to match pattern written out in notebook
                    numTerms = firstYValue - rowOfPatternChange;

                    BigInteger firstTerm = rowOfPatternChange * rowOfPatternChange;
                    BigInteger subsequentIncrements = firstTerm;
                    int i = 1;

                    BigInteger finalIncValue = 1;
                    while (i < (firstYValue / rowOfPatternChange)) // the division that gives how many times we jump by increment as a whole number
                    {
                        finalIncValue = i * subsequentIncrements;

                        // ----- dealing with loss
                        if (finalIncValue > loss)
                        {
                            aSumRemainingColumns += (finalIncValue - loss) * rowOfPatternChange;
                        }

                        i++;
                    }

                    //BigInteger lastTerm = 4 * (numTerms / 2);

                    //aSum = ((numTerms / 2) * (firstTerm + lastTerm)) / 2;

                    //aSumRemainingColumns += 2 * aSum;
                    if ((firstYValue % rowOfPatternChange) != 0)
                    {
                        // ----- dealing with loss
                        if (finalIncValue > loss)
                        {
                            aSumRemainingColumns += (firstYValue % rowOfPatternChange) * (finalIncValue - loss);
                        }
                    }
                }


            }

            // Use to DEBUG if remaining columns eqns are correct -------------- 
            //BigInteger remainingColumnXors = 0;
            //for (var i = 0; i < firstYValue; i++)
            //{
            //    for (var j = firstYValue; j < x; j++)
            //    {
            //        var xor = i ^ j;
            //        if (xor > loss)
            //        {
            //            remainingColumnXors += xor - loss;
            //        }
            //    }
            //}
            //aSumRemainingColumns = remainingColumnXors;
            // -----------------------------------------------------------------------




            // calculate remaining rectangle sums
            BigInteger remainingXors = 0;
            for (var i = firstYValue; i < x; i++)
            {
                for (var j = firstYValue; j < y; j++)
                {
                    var xor = i ^ j;
                    if (xor > loss)
                    {
                        remainingXors += xor - loss;
                    }
                }
            }



            BigInteger total = sumFirstSquare + aSumRemainingRows + aSumRemainingColumns + remainingXors;

            var timeWrapped = total % timeLimit;

            return (long)timeWrapped;
        }


        // y is multiplier
        internal static BigInteger AriSum(BigInteger x, BigInteger y, BigInteger loss)
        {
            BigInteger numTerms = 0;
            if (loss > 0)
            {
                numTerms = x - (loss + 1);
            }
            else
            {
                numTerms = x - 1;
            }

            if (x > loss)
            {
                BigInteger aSum = (numTerms * (1 + x - (loss + 1))) / 2;
                return aSum * y;
            }
            else
            {
                return 0;
            }

        }




        ///// set true to enable debug
        //public static bool Debug = false;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n">Rectangle dimension</param>
        ///// <param name="m">Rectangle dimension</param>
        ///// <param name="loss">Transmission loss in seconds</param>
        ///// <param name="timeLimit">Time in seconds, after which to wrap around to 0 seconds and begin counting again</param>
        ///// <returns></returns>
        //public static long ElderAge(long n, long m, long loss, long timeLimit)
        //{
        //    long eldersTime = 0;
        //    long xor = 0;
        //    long largerAxis = n > m ? n : m;
        //    long smallerAxis = n > m ? m : n;

        //    //for (long i = loss+1; i < n; i++)
        //    //{
        //    //    for (long j = 0; j < m; j++)
        //    //    {
        //    //        xor = i ^ j;
        //    //        if (xor > loss)
        //    //        {

        //    //            eldersTime += xor - loss;
        //    //            //eldersTime = AddTimeToElder(eldersTime, timeLimit, (xor - loss));
        //    //        }
        //    //    }
        //    //}

        //    //for (long i = 0; i < loss+1; i++)
        //    //{
        //    //    for (long j = loss+1; j < m; j++)
        //    //    {
        //    //        xor = i ^ j;
        //    //        if (xor > loss)
        //    //        {

        //    //            eldersTime += xor - loss;
        //    //            //eldersTime = AddTimeToElder(eldersTime, timeLimit, (xor - loss));
        //    //        }
        //    //    }
        //    //}


        //    //////////////////////////////////////////////////////////////////////////////////////////////////////// end naive soln

        //    // calculate every other line (pairs)
        //    // reduce data set based on smaller than loss






        //    //long Task1EldersTime = 0;

        //    //for (long x = 0; x < smallerAxis; x++)
        //    //{
        //    //    long y = x;
        //    //    while (y < smallerAxis)
        //    //    {
        //    //        xor = x ^ y;
        //    //        if (xor > loss)
        //    //        {
        //    //            //eldersTime += xor - loss;
        //    //            Task1EldersTime = AddTimeToElder(Task1EldersTime, timeLimit, (long)(xor - loss));
        //    //        }
        //    //        y++;
        //    //    }

        //    //}
        //    //Task1EldersTime = AddTimeToElder(Task1EldersTime, timeLimit, Task1EldersTime);


        //    //for (long i = smallerAxis; i < largerAxis; i++)
        //    //{
        //    //    for (long j = 0; j < smallerAxis; j++)
        //    //    {
        //    //        xor = i ^ j;
        //    //        if (xor > loss)
        //    //        {
        //    //            //eldersTime += xor - loss;
        //    //            eldersTime = AddTimeToElder(eldersTime, timeLimit, (long)(xor - loss));

        //    //        }
        //    //    }
        //    //}

        //    ////eldersTime *= 2;            


        //    //eldersTime = AddTimeToElder(eldersTime, timeLimit, Task1EldersTime);

        //    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// end second pass soln
        //    long y;


        //    // if row is even and row+1 < smallerAxis

        //    // if even number of columns
        //    // row + 1 = current row summations

        //    // if odd number of columns
        //    // row + 1 = current row summation + 1



        //    // each line is an arithmetic series where
        //    // sum = [number of terms * (first term + last term)] / 2
        //    if ((n % 2 != 0) && (m % 2 != 0))
        //    //if (false)
        //    {
        //        //n = largerAxis;
        //        //m = smallerAxis;
        //        BigInteger nBig = BigInteger.Parse(n.ToString());
        //        BigInteger mBig = BigInteger.Parse(m.ToString());

        //        BigInteger numTerms = n - (loss + 1);


        //        //BigInteger arithmeticSeriesSum = (numTerms * (1 + numTerms)) / 2;
        //        BigInteger arithmeticSeriesSum = (numTerms * (loss + 1 + n)) / 2;

        //        BigInteger testTime = m * arithmeticSeriesSum;


        //        var additionalSum = ((m - 1) * (1 + (m - 1))) / 2;


        //        testTime += additionalSum;

        //        testTime = testTime % (timeLimit);

        //        return (long)testTime;
        //    }
        //    else
        //    {
        //        // there is something going on with multiples of 8
        //        BigInteger nBig = BigInteger.Parse(n.ToString());
        //        BigInteger mBig = BigInteger.Parse(m.ToString());

        //        BigInteger numTerms = n - (loss + 1);

        //        BigInteger arithmeticSeriesSum = (numTerms * (1 + numTerms)) / 2;

        //        BigInteger testTime = m * arithmeticSeriesSum;
        //        testTime = testTime % (timeLimit);

        //        return (long)testTime;
        //    }









        //    //long numTerms = n - (loss + 1);

        //    //long arithmeticSeriesSum = (numTerms * (1 + numTerms)) / 2;

        //    //eldersTime = m * arithmeticSeriesSum;

        //    //eldersTime = eldersTime % (timeLimit);


        //    //y = 0;
        //    //long rowStart = loss + 1;
        //    //while (y < smallerAxis)
        //    //{
        //    //    if (y == rowStart)
        //    //    {
        //    //        rowStart += loss + 1;
        //    //    }


        //    //    for (long x = rowStart; x < smallerAxis; x++)
        //    //    {
        //    //        xor = x ^ y;
        //    //        var test = xor - loss;
        //    //        if (xor > loss)
        //    //        {
        //    //            //eldersTime += xor - loss;
        //    //            eldersTime = AddTimeToElder(eldersTime, timeLimit, (long)(xor - loss));
        //    //        }
        //    //    }

        //    //    y++;
        //    //}
        //    //eldersTime *= 2;



        //    //for (long x = smallerAxis; x < largerAxis; x++)
        //    //{
        //    //    for (y = 0; y < smallerAxis; y++)
        //    //    {
        //    //        xor = x ^ y;
        //    //        if (xor > loss)
        //    //        {
        //    //            //eldersTime += xor - loss;
        //    //            eldersTime = AddTimeToElder(eldersTime, timeLimit, (long)(xor - loss));

        //    //        }
        //    //    }
        //    //}



        //    //eldersTime = eldersTime % (timeLimit);
        //    //return eldersTime; // do it!

        //}












        //private static long AddTimeToElder(long eldersTime, long timeLimit, long timeToAdd)
        //{
        //    long output = eldersTime + timeToAdd;
        //    if (output > timeLimit)
        //    {
        //        output = output % timeLimit;
        //    }

        //    return output;
        //}

    }
}
