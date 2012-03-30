using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class StringCalculator
    {
        public int Sum(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var individualNumbers = numbers.Split(',', '\n');
            if(individualNumbers.Any(string.IsNullOrEmpty))
                throw new ArgumentException();
            return individualNumbers.Sum(individualNumber => int.Parse(individualNumber));
        }
    }
}
