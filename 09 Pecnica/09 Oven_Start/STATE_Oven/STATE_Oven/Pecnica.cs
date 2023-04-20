using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_Oven
{
    partial class Pecnica
    {
        public string NazivPecnice { get; set; }
        public ProgramRada Program { get; set; }

        public Pecnica()
        {
            NazivPecnice = "Electrolux 14232";
            MatricaDogadaja();
        }
    }
}
