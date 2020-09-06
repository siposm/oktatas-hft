using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazifeladat
{
    class SavedLivesAttribute : Attribute
    {
        public int Limit { get; set; }
        public string Percentage { get; set; }

        public SavedLivesAttribute(string percentage, int limit)
        {
            this.Percentage = percentage;
            this.Limit = limit;
        }
    }
}
