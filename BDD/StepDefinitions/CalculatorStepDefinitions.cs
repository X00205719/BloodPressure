using BPCalculator;
using System;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private readonly BloodPressure _bloodPressure = new();

        [Given(@"the Systolic number is (.*)")]
        public void GivenTheSystolicNumberIs(int p0)
        {
            _bloodPressure.Systolic = p0;
        }

        [Given(@"the Diastolic number is (.*)")]
        public void GivenTheDiastolicNumberIs(int p0)
        {
            _bloodPressure.Diastolic = p0;
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeIdeal(string expectedCategory)
        {
            BPCategory expectedEnumCategory = Enum.Parse<BPCategory>(expectedCategory);

            _bloodPressure.Category.Should().Be(expectedEnumCategory);
        }
    }
}
