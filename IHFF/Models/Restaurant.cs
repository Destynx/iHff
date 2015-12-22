using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Restaurant : Product
    {
        string Keuken;
        DateTime Openingstijd;
        DateTime Dinnerswitch;
        DateTime Sluitingstijd;
    }
}