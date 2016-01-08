using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Restaurant : Product
    {
        public string Keuken;
        public DateTime Openingstijd;
        public DateTime Dinnerswitch;
        public DateTime Sluitingstijd;
    }
}