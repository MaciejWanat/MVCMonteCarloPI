using Xunit;
using MVCMonteCarloPI.Entities;
using ImageSharp;

namespace MVCMonteCarloPiTest.Entities
{
    public class PICalculationModelTest
    {
        [Fact]
        public void CalculatePI_ValidInput_IsValidShouldBeTrue()
        {
            //Arrange
            var calc1 = new PICalculationModel { PointsAmount = 100, SquareSide = 100 };
            var calc2 = new PICalculationModel { PointsAmount = 50890, SquareSide = 891 };

            //Act
            calc1.CalculatePI();
            calc2.CalculatePI();

            //Assert
            Assert.True(calc1.isValid);
            Assert.True(calc2.isValid);
        }
        
        [Fact]
        public void CalculatePI_ValidInput_IsValidShouldBeTrue_EdgeCases()
        {        
            var calc1 = new PICalculationModel { PointsAmount = 100000000, SquareSide = 1000 };
            var calc2 = new PICalculationModel { PointsAmount = 1, SquareSide = 10 };

            calc1.CalculatePI();
            calc2.CalculatePI();

            Assert.True(calc1.isValid);
            Assert.True(calc2.isValid);
        }

        [Theory]
        [InlineData(1000000001)]
        [InlineData(1005000020)]
        [InlineData(0)]
        [InlineData(-10)]
        public void CalculatePI_InvalidPointsAmount_IsValidShouldBeFalse(int pointsAmount)
        {
            var calc = new PICalculationModel { PointsAmount = pointsAmount, SquareSide = 100 };

            calc.CalculatePI();

            Assert.False(calc.isValid);
        }

        [Theory]
        [InlineData(100000)]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-10)]
        public void CalculatePI_InvalidSquareSide_IsValidShouldBeFalse(int squareSide)
        {
            var calc = new PICalculationModel { PointsAmount = 100, SquareSide = squareSide };

            calc.CalculatePI();

            Assert.False(calc.isValid);
        }

        [Fact]
        public void CalculatePI_GoodInput_CalculatedPIShouldBeApproximatedProperly()
        {
            var calc = new PICalculationModel { PointsAmount = 10000, SquareSide = 500 };

            calc.CalculatePI();

            Assert.InRange(calc.CalculatedPI, 3, 4);
        }

    }
}