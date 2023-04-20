using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_ServisniZahtjev
{
    partial class ServisniZahtjev
    {
        public enum Stanje
        {
            UIzradi,
            Podnesen,
            Zaprmiljen,
            UPostupku,
            ZahtjevZatvoren,
            Odbijen
        }

        public enum Dogadaj
        {
            Podnesi,
            Zaprimi,
            Započni,
            Zatvori,
            Odbij
        }

        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDoagajda(Dogadaj dogadaj)
        {
            strojStanja[(int)TrenutnoStanje, (int)dogadaj].Invoke();
        }

        public void MatricaDogadaja()
        {
            TrenutnoStanje = Stanje.UIzradi;

            strojStanja = new Action[4, 5]
            {
                {Podnesi,      null,       null,       null,       null }, //UIzradi
                {null,      Zaprimi,       null,       null,       Odbij }, //Podnsen
                {null,      null,       Započni,       null,       null }, //Zaprimljen
                {null,      null,       null,       Zatvori,       null }, //UPostupku
            };
        }

        public void Podnesi()
        {
            TrenutnoStanje = Stanje.Podnesen;
        }

        public void Zaprimi()
        {
            TrenutnoStanje = Stanje.Zaprmiljen;
        }

        public void Započni()
        {
            TrenutnoStanje = Stanje.UPostupku;
        }

        public void Zatvori()
        {
            TrenutnoStanje = Stanje.ZahtjevZatvoren;
        }

        public void Odbij()
        {
            TrenutnoStanje = Stanje.Odbijen;
        }

        public void PodnesiZahtjev(string opis, DateTime datumIzrade)
        {
            Opis = opis;
            DatumIzrade = datumIzrade;
            ObradiDoagajda(Dogadaj.Podnesi);
        }

        public void ZaprimiZahtjev(DateTime datumZaprimanja)
        {
            DatumZaprimanja = DateTime.Now;
            ObradiDoagajda(Dogadaj.Zaprimi);
        }


        public void ZapocniServisiranje(DateTime datumPocetka)
        {
            DatumPocetka = datumPocetka;
            ObradiDoagajda(Dogadaj.Započni);
        }

        public void ZatvoriZahtjev(DateTime datumDovrsetka)
        {
            DatumZatvaranja = datumDovrsetka;
            ObradiDoagajda(Dogadaj.Zatvori);
        }

        public void OdbijZahtjev()
        {
            DatumOdbijanja = DateTime.Now;
            ObradiDoagajda(Dogadaj.Odbij);
        }
    }
}
