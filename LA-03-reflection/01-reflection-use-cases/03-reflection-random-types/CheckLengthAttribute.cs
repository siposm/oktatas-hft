namespace _03_reflection_random_types
{
    [AttributeUsage(AttributeTargets.Property)]
    class CheckLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
    }
}
