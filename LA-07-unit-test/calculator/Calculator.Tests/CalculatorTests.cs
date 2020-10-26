using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc { get; set; }

        [SetUp]
        public void Setup()
        {
            this.calc = new Calculator();
        }

        [Test]
        public void CalaculatorAddition()
        {
            // ARRANGE
            // in Setup method

            // ACT
            int res = calc.Add(10, 20);

            // ASSERT
            Assert.That(res, Is.EqualTo(30));
        }

        [TestCase(1, 1, 0)]
        [TestCase(1, 10, -9)]
        [TestCase(100, 1, 99)]
        [TestCase(1, 2, -1)]
        public void CalculatorSubtraction(int from, int what, int expected)
        {
            int res = calc.Sub(from, what);
            Assert.That(res, Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(10, 10, 100)]
        [TestCase(-2, 10, -20)]
        public void CalculatorMultiplication(int a, int b, int expected)
        {
            int res = calc.Mul(a, b);
            Assert.That(res, Is.EqualTo(expected));
        }

        [TestCase(2, 2, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(20, 2, 10)]
        [TestCase(-4, 2, -2)]
        [TestCase(-2, -2, 1)]
        [TestCase(-20, -2, 10)]
        public void CalculatorDivision_ExpectedResult(int what, int with, double expected)
        {
            double res = calc.Div(what, with);
            Assert.That(res, Is.EqualTo(expected));
        }

        [TestCase(2, 0)]
        [TestCase(20, 0)]
        [TestCase(200, 0)]
        [TestCase(-1, 0)]
        public void CalculatorDivision_ThrowsException(int what, int with)
        {
            Assert.That(() => calc.Div(what, with), Throws.TypeOf<DivideByZeroException>());
        }
    }
}