using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    public class Repository : IRepository
    {
        public List<Avenger> Avengers { get; set; }

        public List<Avenger> GetAvengers()
        {
            List<Avenger> lista = new List<Avenger>();

            // TODO: add items from entity framework

            lista.Add(new Avenger()
            {
                Name = "Tony Stark", Gender = false, SuperPower = false
            });

            lista.Add(new Avenger()
            {
                Name = "Hulk", Gender = false, SuperPower = true
            });

            lista.Add(new Avenger()
            {
                Name = "Black Widow", Gender = true, SuperPower = false
            });
            return lista;
        }

        public void AddAvenger(Avenger avenger)
        {
            // itt már nem kell szűrni, de itt is lehetne ezt-azt vizsgálni
            this.Avengers.Add(avenger);
        }
    }
}
