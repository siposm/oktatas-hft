using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazifeladat
{
    class Avenger
    {
        public string Name { get; set; }

        [SavedLives("5%", 30)]
        public int SavedQuantity { get; set; }

        [Avenger(CurrentLocation.Titan)]
        public void Fight()
        {

        }

        public override string ToString()
        {
            return this.Name;
        }
    }



    class NotAvenger
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

}
