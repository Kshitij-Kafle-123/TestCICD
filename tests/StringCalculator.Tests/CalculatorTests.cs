using System;
using Xunit;
using StringCalculatorLib;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var calc = new Calculator();
            Assert.Equal(0, calc.Add(""));
        }

        [Fact]
        public void Add_SingleNumber_ReturnsNumber()
        {
            var calc = new Calculator();
            Assert.Equal(1, calc.Add("1"));
        }

        [Fact]
        public void Add_TwoNumbers_CommaSeparated_ReturnsSum()
        {
            var calc = new Calculator();
            Assert.Equal(3, calc.Add("1,2"));
        }

        [Fact]
        public void Add_NewlineDelimiter_Works()
        {
            var calc = new Calculator();
            Assert.Equal(6, calc.Add("1\n2,3"));
        }

        [Fact]
        public void Add_CustomSingleCharDelimiter_Works()
        {
            var calc = new Calculator();
            Assert.Equal(3, calc.Add("//;\n1;2"));
        }

        [Fact]
        public void Add_MultipleCustomDelimiters_Works()
        {
            var calc = new Calculator();
            Assert.Equal(6, calc.Add("//[***][%]\n1***2%3"));
        }

        [Fact]
        public void Add_NegativeNumbers_Throws()
        {
            var calc = new Calculator();
            var ex = Assert.Throws<ArgumentException>(() => calc.Add("1,-2,3,-4"));
            Assert.Contains("-2", ex.Message);
            Assert.Contains("-4", ex.Message);
        }

        [Fact]
        public void Add_NumbersGreaterThan1000_Ignored()
        {
            var calc = new Calculator();
            Assert.Equal(2, calc.Add("2,1001"));
        }
    }
}
