using ImageSharp;
using System;

namespace MVCMonteCarloPI.Entities
{
    public class PICalculationModel
    {
        public int PointsAmount { get; set; }
        public int SquareSide { get; set; }
        public double CalculatedPI { get; set; }
        public string ImagePath { get; set; }
        public bool? isValid { get; set; } 

        public void CalculatePI() //function that calculates PI and draws graphic representation of an object
        {
            if (ValidateInput() == true)
            {
                isValid = true;
                using (Image<Rgba32> image = new Image<Rgba32>(SquareSide, SquareSide)) //set background, make image
                {
                    image.BackgroundColor(Rgba32.White);
                    image.Save("wwwroot/images/image.png");
                }

                DrawCircle("wwwroot/images/image.png", SquareSide / 2);
                DrawBorders("wwwroot/images/image.png", SquareSide);

                int i = 0;
                int numInCircle = 0;
                int total = 0;
                Random rnd = new Random();

                using (Image<Rgba32> image = Image.Load("wwwroot/images/image.png"))
                {
                    while (i < PointsAmount)
                    {
                        int x = rnd.Next(0, SquareSide); // points in rectangle
                        int y = rnd.Next(0, SquareSide);

                        float center = SquareSide / 2;

                        float Cx = x - center;
                        float Cy = y - center;

                        if (Cx * Cx + Cy * Cy <= SquareSide / 2 * SquareSide / 2) // Is the point in the circle?
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

                CalculatedPI = 4.0 * ((double)numInCircle / (double)total);
                ImagePath = "~/images/image.png";
            }
            else
            {
                isValid = false;
            }

        }

        private static void DrawCircle(string imagePath, double radius)
        {
            using (Image<Rgba32> image = Image.Load(imagePath.ToString()))
            {
                for (double l = 0.0; l < 360.0; l += 0.1)
                {
                    double angle = l * System.Math.PI / 180;
                    int x = (int)(radius + radius * System.Math.Cos(angle));
                    int y = (int)(radius + radius * System.Math.Sin(angle));

                    image[x, y] = Rgba32.Red;
                }

                image.Save(imagePath.ToString());
            }
        }

        private static void DrawBorders(string imagePath, int squareSize)
        {
            using (Image<Rgba32> image = Image.Load(imagePath.ToString()))
            {
                for (int i = 0; i <= squareSize; i++)
                {
                    image[i, 0] = Rgba32.Black;             // horizontal
                    image[i, squareSize - 1] = Rgba32.Black;

                    image[0, i] = Rgba32.Black;             // vertical
                    image[squareSize - 1, i] = Rgba32.Black;
                }                     

                image.Save(imagePath.ToString());
            }
        }

        private bool ValidateInput()
        {
            if (PointsAmount >= 1 && PointsAmount <= 100000000 && SquareSide >= 10 && SquareSide <= 1000)
                return true;

            return false;
        }

    }
}
