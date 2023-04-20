using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_ServisniZahtjev
{
    partial class ServisniZahtjev
    {
        public string Opis { get; set; }
        public DateTime DatumIzrade { get; set; }
        public DateTime DatumZaprimanja { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZatvaranja { get; set; }
        public DateTime DatumOdbijanja { get; set; }
        
        public ServisniZahtjev()
        {
            MatricaDogadaja();
        }
    }
}
