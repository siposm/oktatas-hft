using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Models
{
    public class CategoryAndCount
    {
        public string Category { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Category} - {Count}";
        }
    }
}
