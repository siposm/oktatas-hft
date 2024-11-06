using System;

namespace _07_reflection_tostring
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string> ProgrammingLanguages { get; set; }
        public string CurrentProject { get; set; }

        public Developer()
        {
            ProgrammingLanguages = new List<string>();
        }

        public override string ToString()
        {
            string x = "";

            foreach (var item in this.GetType().GetProperties())
            {
                if (item.Name.Equals("ProgrammingLanguages"))
                {
                    x += "\t* ";
                    x += item.Name + " => ";
                    x += string.Join(", ", ProgrammingLanguages);
                    x += "\n";
                }
                else
                {
                    x += "\t* ";
                    x += item.Name + " => ";
                    x += item.GetValue(this);
                    x += "\n";
                }
            }

            return x;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Developer dev1 = new Developer
            {
                Id = 1,
                Name = "Alice Smith",
                Specialty = "Frontend",
                YearsOfExperience = 5,
                ProgrammingLanguages = new List<string> { "JavaScript", "TypeScript", "HTML", "CSS" },
                CurrentProject = "Web Dashboard"
            };

            Developer dev2 = new Developer
            {
                Id = 2,
                Name = "Bob Johnson",
                Specialty = "Backend",
                YearsOfExperience = 8,
                ProgrammingLanguages = new List<string> { "C#", "SQL", "Python" },
                CurrentProject = "E-commerce API"
            };

            Developer dev3 = new Developer
            {
                Id = 3,
                Name = "Charlie Brown",
                Specialty = "Full Stack",
                YearsOfExperience = 6,
                ProgrammingLanguages = new List<string> { "JavaScript", "C#", "React", "Node.js" },
                CurrentProject = "Mobile App Development"
            };

            List<Developer> developers = new List<Developer> { dev1, dev2, dev3 };

            foreach (var item in developers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
