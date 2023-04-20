using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RentACar
{
    partial class Vozilo
    {
        public enum Stanje
        {
            Raspoloziv,
            UKvaru,
            Rezerviran,
            UUporabi,
            NaPregledu
        }
        public enum Dogadaj
        {
            Kvar,
            PopravljenKvar,
            KlijentZatrazioVozilo,
            KlijentStigaoPoAuto,
            KlijentVracaAuto,
            VoziloSpremnoZaUporabu
        }

        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDogadaj(Dogadaj dogadaj)
        {
            this.strojStanja[(int)this.TrenutnoStanje, (int)dogadaj].Invoke();
        }

        private void DefinirajMatricuPrijelaza()
        {
            TrenutnoStanje = Stanje.Raspoloziv;

            this.strojStanja = new Action[5, 6]
            {
                //Kvar                      //PopravljenKvar       //KlijentZatrazioVozilo    //KlijentStigao     //KlijentVracaAuto      //VoziloSpremno
                {Kvar,                      null,                   KlijentZatrazioVozilo,    null,               null,                   null}, //Raspolozivo
                {null,                      PopravljenKvar,         null,                     null,               null,                   null}, //UKvaru
                {null,                      null,                   null,                     KlijentStigaoPoAuto,null,                   null}, //Rezerviran
                {null,                      null,                   null,                     null,               KlijentVracaAuto,       null}, //UUporabi
                {null,                      null,                   null,                     null,               null,                   VoziloSpremnoZaUporabu}, //Napregledu
            };
        }
        private void Kvar()
        {
            TrenutnoStanje = Stanje.UKvaru;
        }
        private void PopravljenKvar()
        {
            TrenutnoStanje = Stanje.Raspoloziv;
        }
        private void KlijentZatrazioVozilo()
        {
            TrenutnoStanje = Stanje.Rezerviran;
        }
        private void KlijentStigaoPoAuto()
        {
            TrenutnoStanje = Stanje.UUporabi;
        }
        private void KlijentVracaAuto()
        {
            TrenutnoStanje = Stanje.NaPregledu;
        }
        private void VoziloSpremnoZaUporabu()
        {
            TrenutnoStanje = Stanje.Raspoloziv;
        }
    }
}
