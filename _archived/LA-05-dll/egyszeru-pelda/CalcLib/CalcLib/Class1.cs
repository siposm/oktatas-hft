using System;

namespace CalcLib
{
    // LÉPÉSEK
    //
    // 1. F6 >> BUILD SOLUTION
    // 2. DLL FÁJL MEGKERESÉSE
    // 3. DLL FÁJL BETALLÓZÁSA A MÁSIK PROJEKTBE (AHOL HASZNÁLNI AKARJUK)



    /// <summary>
    /// Calculator osztály, amellyel a .dll fájlok használata kerül bemutatásra.
    /// Metódusai: Addition, Substraction
    /// </summary>
    public class Calculator
    {
        public int Addition(int a, int b)
        {
            return a + b;
        }

        public int Substraction(int from, int what)
        {
            return from - what;
        }
    }
}
