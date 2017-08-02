using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMonteCarloPI.Entities;

namespace MVCMonteCarloPI
{
    public class Logic
    {
        public static double CalculatePI(int pointsAmount, int squareSide)
        {
            int i = 0;
            int numInCircle = 0;
            int total = 0;
            Random rnd = new Random();

            while (i < pointsAmount)
            {
                int x = rnd.Next(0, squareSide); // points in rectangle
                int y = rnd.Next(0, squareSide);

                float center = squareSide / 2;

                float Cx = x - center;
                float Cy = y - center;

                if (Cx * Cx + Cy * Cy <= squareSide / 2 * squareSide / 2) // Is the point in the circle?
                {         
                    ++numInCircle;
                }

                ++total;
                i++;
            }

            double piApproximation = 4.0 * ((double)numInCircle / (double)total);

            return piApproximation;
        }
    }
}
