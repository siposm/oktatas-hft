namespace _08_reflection_xml_export
{
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
}
