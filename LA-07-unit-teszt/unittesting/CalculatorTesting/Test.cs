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


    }
}
