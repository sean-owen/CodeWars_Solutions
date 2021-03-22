using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace KataSolutions.FabergeEasterEggsCrushTest
{
    // TODO - come back to me!
    public class FabergeEasterEggsCrushTestKata
    {
        public static BigInteger Height(int n, int m)
        {

            

            int numberOfEggs = n;
            int numberOfThrows = m;

            // what is the max height you can have such that you can find the floor on which an egg breaks?

            // binary search...?

            if (numberOfEggs == 1)
            {
                return numberOfThrows;
            }

            if (numberOfThrows == 1)
            {
                return 1;
            }

            // assume max floor = 105, numberOfEggs = 2, numberOfThrows = 14
            
            BigInteger maxFloor = 0;

            maxFloor = numberOfThrows * numberOfEggs;
            return 0;
        }
    }
}
