namespace _08_reflection_xml_export
{
    class Cat : Animal
    {
        public Cat()
        {
            Herbivorous = false;
        }

        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int NumberOfLives { get; set; }

        public string Greet() { return "szia"; }

        [MethodToXML]
        public void Meow() { }

        [MethodToXML]
        public int Walk() { return 0; }

        [MethodToXML]
        public double ClimbToTree(string a, bool b) { return 0.5; }
    }
}
