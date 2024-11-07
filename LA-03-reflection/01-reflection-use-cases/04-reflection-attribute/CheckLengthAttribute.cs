namespace _04_reflection_attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    class CheckLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
    }
}
