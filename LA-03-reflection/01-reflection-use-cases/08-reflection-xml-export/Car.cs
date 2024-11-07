namespace _08_reflection_xml_export
{
    [ModelToXML]
    class Car
    {
        public string License { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
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
