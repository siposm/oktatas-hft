﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    public class AvengerController
    {
        IRepository repo;

        // dependency !!!
        public AvengerController(IRepository repo)
        {
            this.repo = repo;
        }

        public List<Avenger> GetAvengers()
        {
            return repo.GetAvengers();
        }

        public List<Avenger> SelectAvengersByGender(bool gender)
        {
            return repo.GetAvengers().Where( x => x.Gender == gender).ToList();
        }

        // maximum kiválasztás pl. legerősebb bosszúálló
        // komolyabb alg. alapján%
        // ezt tesztelni jó a mock-kal
        
        // mock mindig azt a 20 elemet biztosítja!!!

        // itt lévő bonyi algoritmusokat tesztelem

            // nem a repo-t teszteljük hanem a controllert!

            // 

        public int AddAvenger(Avenger avenger)
        {
            // vizsgálat
            bool exist = false;
            if(avenger != null)
            {
                foreach (Avenger item in repo.GetAvengers())
                {
                    if (item.Name == avenger.Name)
                    {
                        exist = true;
                    }
                }

                if (!exist)
                    return repo.AddAvenger(avenger);
                else
                    throw new AvengerExistsException("This Avenger already exists in the database.");
            }
            throw new NullReferenceException("Null reference was caused from AddAvenger.");
        }

        public Avenger SelectAvengerByIndex(int index)
        {
            // vizsgálat
            if(index >= 0)
            {
                if(index < repo.GetAvengers().Count)
                {
                    // hívás
                    return repo.GetAvengers()[index];
                }
            }
            throw new IndexOutOfRangeException("Not valid index was given.");
        }

        public Avenger GetStrongestAvenger()
        {
            if(repo.GetAvengers().Count > 0)
                return repo.GetAvengers().Where(x => x.Name == "Thor").FirstOrDefault();
            else
                throw new Exception("Avengers list is empty.");
        }

        public List<Avenger> AvengersAssemble()
        {
            if (repo.GetAvengers().Count > 0)
                return repo.GetAvengers().Where( x => x.SuperPower == true).ToList();
            else
                throw new Exception("Avengers list is empty.");
        }

        public List<Avenger> GetStrongestAvengers(int number)
        {
            if (repo.GetAvengers().Count > 0)
                return repo.GetAvengers().OrderByDescending( x => x.Strength).Take(number).ToList();
            else
                throw new Exception("Avengers list is empty.");
        }
    }
}
