using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// references >> add >> unittesting (vagy a megfelelő namespace)
// utána using-olni
using unittesting;

namespace CalculatorTesting
{
    /*
     * NUnit telepítése
     * 
     * 1. lépés
     * [TestFixture] beírás >> refactor felkínálása >> install NUnit latest...
     * VAGY
     * sln explorer >> manuális telepítés kézzel (jobb klikk... manage nuget packages)
     * 
     * 2. lépés
     * manage nuget >> install NUnit 3 test adapter
     * 
     * */

    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void AdditionTest()
        {
            // ARRANGE = előkészítés
            Calculator calc = new Calculator();

            // ACT = 1 db fgv lefuttatása
            int x = calc.Addition(10, 20);

            // ASSERT = ellenőrzés
            Assert.That(x, Is.EqualTo(30));
        }

        [Test]
        public void MultiplicationTest()
        {
            // ARRANGE = előkészítés
            Calculator calc = new Calculator();

            // ACT = 1 db fgv lefuttatása
            int x = calc.Multiplication(10, 20);

            // ASSERT = ellenőrzés
            Assert.That(x, Is.EqualTo(200));
        }

        [Test]
        public void DivisionResultTest()
        {
            Calculator calc = new Calculator();
            double result = calc.Division(10, 3);
            Assert.That(result, Is.EqualTo(10 / 3));
        }

        [Test]
        public void DivisionExceptionTest()
        {
            Calculator calc = new Calculator();
            Assert.That(() => calc.Division(10, 0), Throws.TypeOf<DivideByZeroException>());
            // () >> nulla db argumentumú delegált
        }

        [Test]
        public void DivisionException2Test()
        {
            Calculator calc = new Calculator();
            Assert.Throws<DivideByZeroException>( () => calc.Division(10, 0));
        }
    }
}
