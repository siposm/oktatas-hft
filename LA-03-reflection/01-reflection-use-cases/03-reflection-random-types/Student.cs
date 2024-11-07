namespace _03_reflection_random_types
{
    class Student : Person
    {
        [CheckLength(MaxLength = 10)]
        public string Email { get; set; }

        public string NeptunID { get; set; }

        public int Credits { get; set; }
    }
}
