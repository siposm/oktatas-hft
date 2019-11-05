using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiszh4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Kérem adja meg a sorok és oszlopok számát: ");
            a = Convert.ToInt16(Console.ReadLine());
            b = Convert.ToInt16(Console.ReadLine());
            MatrixLetrehozEsFeltolt(a, b);
           // Console.WriteLine(MatrixMegjelenit(MatrixLetrehozEsFeltolt(a,b)));


        }

        static bool[,] MatrixLetrehozEsFeltolt(int a, int b)
        {          
            
            Random rand = new Random();
            bool[,] tomb = new bool[b, a];
            for(int i=0;i<b;i++)
            {
                for(int j=0;j<a;j++)
                {
                    if (rand.Next(0, 2) == 0)
                        tomb[i, j] = false;
                    else
                        tomb[i, j] = true; ;
                }
            }

            return tomb;
        }

        static string MatrixMegjelenit(bool[,] matrix)
        {
            string elemek = "";
            int i = 0, j = 0;
            do
            {
                do
                {
                    if (matrix[i, j] == true)
                    {
                     elemek=elemek+" 1";
                    }
                    else
                    {
                        elemek = elemek + " 0";
                    }
                    j++;
                } while (matrix[i, j] != null);

                elemek = elemek + "\n";
                i++;
            } while (matrix[i, j] != null);

            return elemek;
        }

        static int MatrixHamisDarabszam(bool[,] matrix)
        {
            int db = 0;
            int i = 0;
            int j = 0;
            do
            {
                do
                {
                    if (matrix[i, j] == false)
                    {
                        db++;
                    }                   
                    j++;
                } while (matrix[i, j] != null);
                i++;
            } while (matrix[i, j] != null);
            return db;
        }
    }
}
