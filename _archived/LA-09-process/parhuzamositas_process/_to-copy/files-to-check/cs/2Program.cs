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
            Console.Write("Adja sorszámot: ");
            int sor = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg az oszlopszámot: ");
            int oszlop = int.Parse(Console.ReadLine());


            Console.WriteLine(MatrixMegjelenit(MatrixLetrehozEsFeltolt(sor, oszlop)));





            Console.ReadLine();
        }
        static bool[,] MatrixLetrehozEsFeltolt(int sor, int oszlop);
        {
        bool[,] matrix = new bool[sor, oszlop];
        Random r = new Random();
        for(int i=0;i<matrix.GetLenght(0);i++)
            {
            for(int j=0;j<matrix.GetLenght(1);j++)
            {
            if(Random.Next(0,2)==0)
            {
            matrix[i, j]=false;
            }
    else
    {
    matrix[i, j]=true;
    
            
}
return matrix;
    }
    }
}
        static string MatrixMegjelenit(bool[,] matrix)
        {
            string megjelenit = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j])
                    {
                        megjelenit += 1;
                    }
                    else
                    {
                        megjelenit += 0;
                    }
                }
                megjelenit += System.Environment.NewLine;
            }
            return megjelenit;
        }
    }
}

    

