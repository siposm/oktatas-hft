using System;

namespace _03_xml
{
    class Animal
    {
        public bool Novenyevo { get; set; }
    }

    class Cat : Animal
    {
        public Cat()
        {
            Novenyevo = false;
        }

        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int EletekSzama { get; set; }

        public string Greet() { return "szia"; }

        [MethodToXML]
        public void Meow() { }

        [MethodToXML]
        public int Walk() { return 0; }

        [MethodToXML]
        public double ClimbToTree(string a, bool b) { return 0.5; }
    }

    [ModelToXML]
    class Dog : Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Female { get; set; }

        [MethodToXML]
        public int Bark()
        {
            return 10; // length of the barking in msp
        }

        public void Greet() { }

        [MethodToXML]
        public double Run() { return 4.009; }

        [MethodToXML]
        public double Walk() { return 432.114; }
    }

    class Student
    {
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void GoesToLecture() { }

        [MethodToXML]
        public void RegisterToSubject() { }

        [MethodToXML]
        public void SkipCourse() { }

        [MethodToXML]
        public void RegisterToExam() { }
    }

    class Car
    {
        public string License { get; set; }
        public string OwnerName { get; set; }
        public bool SportCar { get; set; }
        public DateTime RegistrationDate { get; set; }

        public void FuelUp() { }

        [MethodToXML]
        public void GoFaster() { }

        [MethodToXML]
        public void GoSlower() { }

        [MethodToXML]
        public void Repair() { }
    }
}