using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_Dishwasher
{
    partial class Perilica
    {
        public string NazivPerilice { get; set; }
        public ProgramRada Program { get; set; }


        public Perilica()
        {
            NazivPerilice = "BOSCH GDS3429";
            MatricaDogadaja();
        }
    }
}
