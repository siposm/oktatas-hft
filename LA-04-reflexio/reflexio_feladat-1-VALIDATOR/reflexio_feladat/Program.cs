using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflexio_feladat
{
    class Person
    {
        [MaxLength(20)]
        public string Name { get; set; }


        [Range(50,300)]
        public int Height { get; set; }
    }

    class MaxLengthAttribute : Attribute
    {
        public int Length { get; set; }
        public MaxLengthAttribute(int l)
        {
            this.Length = l;
        }
    }

    class RangeAttribute : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public RangeAttribute(int min = int.MinValue, int max = int.MaxValue) // csak (int) tartományban dolgozunk
        {
            this.Min = min;
            this.Max = max;
        }
    }

    interface IValdiation
    {
        bool Validate(object instance, PropertyInfo propertyInfo);
    }

    // ctrl + . >> implement interface
    class MaxLengthValidation : IValdiation
    {
        MaxLengthAttribute maxLength;
        public MaxLengthValidation(MaxLengthAttribute ml)
        {
            this.maxLength = ml;
        }

        public bool Validate(object instance, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                var value = (string)propertyInfo.GetValue(instance);
                return value.Length <= maxLength.Length;
            }
            else
                throw new InvalidOperationException();
        }
    }

    class RangeValidation : IValdiation
    {
        RangeAttribute range;
        public RangeValidation(RangeAttribute range)
        {
            this.range = range;
        }

        public bool Validate(object instance, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(int))
            {
                var value = (int)propertyInfo.GetValue(instance);
                return value >= range.Min && value <= range.Max;
            }
            else
                throw new InvalidOperationException();
        }
    }

    class ValidationFactory
    {
        public IValdiation GetValidation(Attribute attribute)
        {
            if (attribute is MaxLengthAttribute)
                return new MaxLengthValidation((MaxLengthAttribute)attribute);

            if (attribute is RangeAttribute)
                return new RangeValidation((RangeAttribute)attribute);

            return null;
        }
    }

    class Validator
    {
        public bool Validate(object instance)
        {
            var validationFactory = new ValidationFactory();

            var properties = instance.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                var allCustomAttributes = propertyInfo.GetCustomAttributes();
                foreach (Attribute customAttribute in allCustomAttributes)
                {
                    var validation = validationFactory.GetValidation(customAttribute);
                    if (validation != null && validation.Validate(instance, propertyInfo) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person validPerson = new Person()
            {
                Name = "Donald Trump",
                Height = 190
            };

            Person invalidPerson1 = new Person()
            {
                Name = "012345678901234567891",
                Height = 190
            };

            Person invalidPerson2 = new Person()
            {
                Name = "Donald Trump",
                Height = 22
            };

            Validator validator = new Validator();
            Console.WriteLine("1st person: " + validator.Validate(validPerson));
            Console.WriteLine("2nd person: " + validator.Validate(invalidPerson1));
            Console.WriteLine("3rd person: " + validator.Validate(invalidPerson2));
        }
    }
}
