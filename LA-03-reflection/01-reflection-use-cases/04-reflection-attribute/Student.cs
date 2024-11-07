namespace _04_reflection_attribute
{
    class Student : Person
    {
        [CheckLength(MaxLength = 10)]
        public string Email { get; set; }
        public string NeptunID { get; set; }
        public int Credits { get; set; }
        public bool? Approved { get; set; } = null;
    }
}
