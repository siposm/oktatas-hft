using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem adja meg a mátrix sor nagyságát:");
            int sor = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg a mátrix oszlop nagyságát:");
            int oszlop = int.Parse(Console.ReadLine());

            bool[,] matrix = MatrixLetrehozEsFeltolt(sor, oszlop);

            Console.WriteLine();
            Console.WriteLine("A mátrix: " + "\n" +MatrixMegjelenit(matrix));
            Console.WriteLine("A mátrixban található igaz értékek darabszáma (1-esek) : " + MatrixIgazDarabszam(matrix) + " db");

            Console.ReadLine();
        }

        static bool[,] MatrixLetrehozEsFeltolt(int sor, int oszlop)
        {
            Random random = new Random();
            bool[,] matrix = new bool[sor, oszlop];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = Convert.ToBoolean(random.Next(0, 2));
                }
            }
            return matrix;
        }

        static string MatrixMegjelenit(bool[,] matrix)
        {
            string szoveg = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == true)
                    {
                        szoveg += "1";
                    }
                    else
                    {
                        szoveg += "0";
                    }
                }
                szoveg += "\n";
            }
            return szoveg;
        }

        static int MatrixIgazDarabszam(bool[,] matrix)
        {
            int db = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix [i, j] == true)
                    {
                        db++;
                    }
                }
            }
            return db;
        }
    }
}
