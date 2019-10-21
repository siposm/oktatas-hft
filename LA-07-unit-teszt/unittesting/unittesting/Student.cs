using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unittesting
{
    public class Student
    {
        public string Name { get; set; }
        public int StartYear { get; set; }

        public int CountSemester()
        {
            return (DateTime.Now.Year - this.StartYear) * 2;
        }

        public void CreateInstanceFromString(string input)
        {            
            if (input.Contains("#"))
                throw new FormatException("not valid format");
            else
            {
                // input = [name]%[year]

                this.Name = input.Split('%')[0];
                this.StartYear = int.Parse(input.Split('%')[1]);
            }
        }
    }
}
