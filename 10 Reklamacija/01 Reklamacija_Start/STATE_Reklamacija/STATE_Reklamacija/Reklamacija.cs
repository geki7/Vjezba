using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_Reklamacija
{
    partial class Reklamacija
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        public string Agent { get; private set; }

        public Reklamacija()
        {
            MatricaDogadaja();
        }
    }
}
