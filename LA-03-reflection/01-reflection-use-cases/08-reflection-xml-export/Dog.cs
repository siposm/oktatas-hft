namespace _08_reflection_xml_export
{
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
}
