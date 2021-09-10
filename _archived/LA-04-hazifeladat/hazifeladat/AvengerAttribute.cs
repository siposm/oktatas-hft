using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazifeladat
{
    class AvengerAttribute : Attribute
    {
        public CurrentLocation Location { get; set; }

        public AvengerAttribute(CurrentLocation location)
        {
            this.Location = location;
        }
    }

    public enum CurrentLocation { Earth, Mars, Vormir, Titan }

}
