namespace _03_reflection_random_types
{
    class BScStudent : Student
    {
        // fields, not properties!

        public int enrollmentYear;
        private int activeSemesters_1; // private is not visible
        public int activeSemesters_2;
        public int activeSemesters_3;
        public int activeSemesters_4;

        public string Greeting()
        {
            return "Hi! I'm " + Name + ", nice to meet you!";
        }
    }
}
