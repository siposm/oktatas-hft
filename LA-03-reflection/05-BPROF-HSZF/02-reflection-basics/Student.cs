﻿namespace _02_reflection_basics
{
    class Student : Person
    {
        [CheckLength(MaxLength = 10)]
        public string Email { get; set; }

        public string NeptunID { get; set; }

        public int Credits { get; set; }
    }
}
