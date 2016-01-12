using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Product
    {
        public int ID;
        public string Naam;
        public Locatie Locatie;
        public string Beschrijving;
        public int Plaatsen;
    }
}