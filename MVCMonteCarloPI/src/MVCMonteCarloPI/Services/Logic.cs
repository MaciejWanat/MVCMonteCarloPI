using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMonteCarloPI.Entities;

namespace MVCMonteCarloPI.Logic
{
    public class Logic
    {
        public double CalculatePI(Properties properties)
        {
            int i = 0;
            int numInCircle = 0;
            int total = 0;
            Random rnd = new Random();

            while (i < properties.PointsAmount)
            {
                int x = rnd.Next(0, properties.SquareSide); // points in rectangle
                int y = rnd.Next(0, properties.SquareSide);

                float center = properties.SquareSide / 2;

                float Cx = x - center;
                float Cy = y - center;

                if (Cx * Cx + Cy * Cy <= properties.SquareSide / 2 * properties.SquareSide / 2) // Is the point in the circle?
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
