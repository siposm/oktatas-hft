namespace _03_LINQ_03
{
    public class Student
    {
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public int BirthYear { get; set; }
        public int EnrollmentYear { get; set; }
        public int CompletedCredits { get; set; }
        public List<Subject> Subjects { get; set; }
        public bool Absolved { get; set; }
        public bool Graduated { get; set; }
    }
}
