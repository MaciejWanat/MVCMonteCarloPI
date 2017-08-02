using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMonteCarloPI.ViewModels
{
    public class MainViewModel
    {
        [Required]
        public int PointsAmount { get; set; }
        public int SquareSide { get; set; }
    }
}
