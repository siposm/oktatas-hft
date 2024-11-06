namespace _02_reflection_basics
{
    [AttributeUsage(AttributeTargets.Property)]
    class CheckLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
    }
}
