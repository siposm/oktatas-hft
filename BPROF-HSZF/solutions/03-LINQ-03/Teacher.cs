namespace _03_LINQ_03
{
    public class Teacher
    {
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public int BirthYear { get; set; }
        public DateTime StartOfEmployment { get; set; }
        public bool HasPhd { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
