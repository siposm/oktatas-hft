using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    interface IRepository
    {
        List<Avenger> Avengers { get; set; }
        List<Avenger> GetAvengers();
    }
}
