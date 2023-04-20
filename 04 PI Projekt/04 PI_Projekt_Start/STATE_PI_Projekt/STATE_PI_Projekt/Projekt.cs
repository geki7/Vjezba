using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_PI_Projekt
{
    partial class Projekt
    {
        public string OpisTeme { get; set; }
        public string OznakaTima { get; set; }
        public DateTime DatumPredaje { get; set; }
        public DateTime DatumObrane { get; set; }

        public Projekt()
        {
            DefinirajMatricuStanja();
        }
    }
}
