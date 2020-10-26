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
    }
}