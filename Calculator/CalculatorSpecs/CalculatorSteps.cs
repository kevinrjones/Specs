using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CalculatorSpecs
{
    [Binding]
    public class CalculatorSteps
    {
        private StringCalculator calculator;
        private int result;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            calculator = new StringCalculator();

        }

        [When(@"I sum an empty string")]
        public void WhenISumAnEmptyString()
        {
            result = calculator.Sum("");
        }

        [When(@"I sum the string '(.*)'")]
        [When(@"I sum the string")]
        public void WhenISumA23(string numbers)
        {
            result = calculator.Sum(numbers);
        }

        [When(@"I sum the invalid string '(.*)'")]
        public void WhenISumAnInvalidString(string invalidString)
        {
            try
            {
                calculator.Sum(invalidString);
            }
            catch (Exception e)
            {
                ScenarioContext.Current["exception"] = e;                
            }
        }
        [Then(@"the calculator should return (.*)")]
        public void ThenTheCalculatorShouldReturn(int sum)
        {
            Assert.That(result, Is.EqualTo(sum));
        }

        [Then(@"an ArgumentException exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            Assert.That(ScenarioContext.Current["exception"], Is.TypeOf<ArgumentException>());
        }
    }    
}
