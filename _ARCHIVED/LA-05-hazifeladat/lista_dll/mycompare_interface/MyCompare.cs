using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycompare_interface
{
    public class ToInsertAttribute : Attribute
    {

    }

    public interface MyCompare <T> : IComparable
    {
        [ToInsert]
        Comparison<T> Comparison { get; set; }
        Predicate<T> Predicate { get; set; }
    }
}
