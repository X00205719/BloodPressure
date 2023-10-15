using BPCalculator;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace UnitTests
{
    public class BloodPressureTests
    {
        [Theory]
        [InlineData(70, 40)]
        [InlineData(70, 59)]
        [InlineData(89, 40)]
        [InlineData(89, 59)]
        public void ShouldBeLow(int systolic, int diastolic)
        {
            var result = new BloodPressure(systolic, diastolic);
            Assert.Equal(BPCategory.Low, result.Category);
        }

        [Theory]
        [InlineData(90, 40)]
        [InlineData(90, 60)]
        [InlineData(70, 60)]
        [InlineData(70, 69)]
        [InlineData(80, 79)]
        [InlineData(119, 79)]
        [InlineData(119, 40)]
        public void ShouldBeIdeal(int systolic, int diastolic)
        {
            var result = new BloodPressure(systolic, diastolic);
            Assert.Equal(BPCategory.Ideal, result.Category);
        }

        [Theory]
        [InlineData(120, 40)]
        [InlineData(120, 80)]
        [InlineData(90, 80)]
        [InlineData(90, 89)]
        [InlineData(139, 89)]
        [InlineData(139, 40)]
        public void ShouldBePreHigh(int systolic, int diastolic)
        {
            var result = new BloodPressure(systolic, diastolic);
            Assert.Equal(BPCategory.PreHigh, result.Category);
        }

        [Theory]
        [InlineData(140, 40)]
        [InlineData(140, 90)]
        [InlineData(91, 90)]
        [InlineData(100, 99)]
        [InlineData(190, 100)]
        [InlineData(190, 40)]
        public void ShouldBeHigh(int systolic, int diastolic)
        {
            var result = new BloodPressure(systolic, diastolic);
            Assert.Equal(BPCategory.High, result.Category);
        }

        [Theory]
        [InlineData(80, 80)]
        [InlineData(69, 40)]
        [InlineData(191, 40)]
        [InlineData(120,39)]
        [InlineData(120,101)]
        public void ShouldThrowError(int systolic, int diastolic)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new BloodPressure(systolic, diastolic));
        }

    }
}