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
    }
}