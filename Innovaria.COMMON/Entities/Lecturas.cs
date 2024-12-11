using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.COMMON.Entities
{
    public class Lecturas
    {
        public int PkLectura { get; set; }
        public decimal Value { get; set; }
        public int FkSensor { get; set; }
        public string Name { get; set; }
    }
}
