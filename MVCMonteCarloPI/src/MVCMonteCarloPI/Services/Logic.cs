using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMonteCarloPI.Entities;
using ImageSharp;
using System.IO;

namespace MVCMonteCarloPI
{
    public class Logic
    {
        
        public static double CalculatePI(int pointsAmount, int squareSide)
        {
            using (Image<Rgba32> image = new Image<Rgba32>(squareSide, squareSide))
            {
                image.BackgroundColor(Rgba32.White);               
                DrawCircle(image, squareSide / 2);
            }            

            int i = 0;
            int numInCircle = 0;
            int total = 0;
            Random rnd = new Random();

            using (Image<Rgba32> image = Image.Load("wwwroot/images/image.png"))
            {
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
                        image[x, y] = Rgba32.Green;
                    }
                    else
                        image[x, y] = Rgba32.Blue;

                    ++total;
                    i++;
                }
                
                image.Save("wwwroot/images/image.png");
            }

            double piApproximation = 4.0 * ((double)numInCircle / (double)total);

            return piApproximation;

        }

        private static void DrawCircle(Image<Rgba32> image, double radius)
        {
            using (image)
            {
                for (double l = 0.0; l < 360.0; l += 0.1)
                {
                    double angle = l * System.Math.PI / 180;
                    int x = (int)(radius + radius * System.Math.Cos(angle));
                    int y = (int)(radius + radius * System.Math.Sin(angle));

                    image[x, y] = Rgba32.Red;
                }

                image.Save("wwwroot/images/image.png");
            }
        }
    }
}
