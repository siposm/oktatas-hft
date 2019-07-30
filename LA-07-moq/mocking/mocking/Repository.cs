﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    class Repository : IRepository
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
    }
}
