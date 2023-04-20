using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_PrepaidKartica
{
    partial class PrepaidKartica
    {
        public enum Stanje
        {
            NijeAktivna,
            Aktivna,
            NemaSredstava
        }
        public enum Dogadaj
        {
            ProdajaKartice,
            UplacenaSredstva,
            NemaSredstava,
            ImaSredstava
        }

        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDogadaja(Dogadaj dogadaj)
        {
            this.strojStanja[(int)this.TrenutnoStanje, (int)dogadaj].Invoke();
        }
        private void DefinirajMatricuPrijelaza()
        {
            TrenutnoStanje = Stanje.NijeAktivna;

            strojStanja = new Action[3, 4]
            {
                { ProdajaKartice,    null,             null,          null },
                { null,              UplacenaSredstva, NemaSredstava, ImaSredstava },
                { null,              UplacenaSredstva, null,          null}
            };
        }

        private void ProdajaKartice()
        {
            TrenutnoStanje = Stanje.Aktivna;
        }

        private void UplacenaSredstva()
        {
            TrenutnoStanje = Stanje.Aktivna;
        }

        private void NemaSredstava()
        {
            TrenutnoStanje = Stanje.Aktivna;
        }

        private void ImaSredstava()
        {
            if(Iznos < 0)
            {
                TrenutnoStanje = Stanje.NemaSredstava;
                
            }
            else
            {
                TrenutnoStanje = Stanje.Aktivna;
            }
        }
    }
}
