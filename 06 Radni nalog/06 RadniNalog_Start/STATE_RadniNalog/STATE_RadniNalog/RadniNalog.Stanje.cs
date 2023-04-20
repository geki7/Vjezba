using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RadniNalog
{
    partial class RadniNalog
    {
        public enum Stanje
        {
            Kreiran,
            Zakljucan,
            PredanUProizvodnju,
            ZapocetaProizvodnja,
            DovrsenaProizvodnja,
            Otkazan
        }
        public enum Dogadaj
        {
            Zaključaj,
            Otkaži,
            PredajProizvodnju,
            ZapočniProizvodnju,
            DovršiProizvodnju
        }
        
        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDogadaj(Dogadaj dogadaj)
        {
            strojStanja[(int)TrenutnoStanje, (int)dogadaj].Invoke();
        }

        public void DefinirajMatricuStanja()
        {
            TrenutnoStanje = Stanje.Kreiran;
            strojStanja = new Action[4, 5]
            {
                {Zakljucaj,      null,       null,       null,       null }, //Kreiran
                {null,      Otkazi,       Predaj,       null,       null }, //Zakljucan
                {null,      null,       null,       Zapocni,       null }, //PredanUProizvodnju
                {null,      null,       null,       null,       Dovrsi }  //DovrsneaProizvodnja
            };
        }

        public void ZakljucajNalog(string opis)
        {
            Opis = opis;
            DatumKreiranja = DateTime.Now;
            ObradiDogadaj(Dogadaj.Zaključaj);
        }

        public void PredajUProizvodnju(DateTime datumPredaje)
        {
            DatumPredaje = DateTime.Now;
            ObradiDogadaj(Dogadaj.PredajProizvodnju);
        }

        public void ZapocniProizvodnju(DateTime datumPocetka)
        {
            DatumPocetka = datumPocetka;
            ObradiDogadaj(Dogadaj.ZapočniProizvodnju);
        }

        public void DovrsiProizvodnju(DateTime datumDovrsetka)
        {
            DatumDovrsetka = datumDovrsetka;
            ObradiDogadaj(Dogadaj.DovršiProizvodnju);
        }

        public void Zakljucaj()
        {
            TrenutnoStanje = Stanje.Zakljucan;
        }

        public void Otkazi()
        {
            TrenutnoStanje = Stanje.Otkazan;
        }

        public void Predaj()
        {
            TrenutnoStanje = Stanje.PredanUProizvodnju;
        }

        public void Zapocni()
        {
            TrenutnoStanje = Stanje.ZapocetaProizvodnja;
        }

        public void Dovrsi()
        {
            TrenutnoStanje = Stanje.DovrsenaProizvodnja;
        }
    }
}
