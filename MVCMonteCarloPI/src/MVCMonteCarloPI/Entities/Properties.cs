using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMonteCarloPI.Entities
{
    public class Properties
    {
        public int PointsAmount { get; set; }
        public int SquareSide { get; set; }
        public double CalculatedPI { get; set; } = 0;
        public string Image { get; set; }

    }
}
