using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_PI_Projekt
{
    partial class Projekt
    {
        public enum Stanje
        {
            TemaNijePrijavljena,
            TemaPrijavljena,
            TemaPrihvacena,
            PredanaPrvaFaza,
            PredanProjekt,
            ProjektOcijenjen
        }
        public enum Dogadaj
        {
            ZabiljeziTemu,
            TemaProvjerena,
            OdbijTemu,
            PrihvatiTemu,
            Predaj,
            PredajSve,
            Ocijeni
        }

        public Stanje TrenutnoStanje { get; set; }
        private Action[,] strojStanja;

        public void ObradiDogadaj(Dogadaj dogadaj)
        {
            strojStanja[(int)TrenutnoStanje, (int)dogadaj].Invoke();
        }

        public void DefinirajMatricuStanja()
        {
            TrenutnoStanje = Stanje.TemaNijePrijavljena;
            strojStanja = new Action[5, 7]
            {
                {Zabiljezi,  null,   null,   null,   null,   null,   null }, //TemaNijePrijavljena
                {null,  null,   Odbij,   Prihvati,   null,   null,   null }, //TemaPrijavljena
                {null,  null,   null,   null,   Predaj,   null,   null }, //TemaPrihvacena
                {null,  null,   null,   null,   null,   PredajSve,   null }, //PredPrvaFaza
                {null,  null,   null,   null,   null,   null,   Ocijeni }  //ProjektPredan
            };
        }

        public void Zabiljezi()
        {
            TrenutnoStanje = Stanje.TemaPrijavljena;
        }
        
        public void Odbij()
        {
            TrenutnoStanje = Stanje.TemaNijePrijavljena;
        }

        public void Prihvati()
        {
            TrenutnoStanje = Stanje.TemaPrihvacena;
        }

        public void Predaj()
        {
            TrenutnoStanje = Stanje.PredanaPrvaFaza;
        }

        public void PredajSve()
        {
            TrenutnoStanje = Stanje.PredanProjekt;
        }

        public void Ocijeni()
        {
            TrenutnoStanje = Stanje.ProjektOcijenjen;
        }

        public void ZabiljeziTemu(string opisTeme, string oznakaTima)
        {
            OpisTeme = opisTeme;
            OznakaTima = oznakaTima;
            ObradiDogadaj(Dogadaj.ZabiljeziTemu);
        }

        public void PredajPrvuFazu(DateTime datumPredaje)
        {
            DatumPredajePrveFaze = datumPredaje;
            ObradiDogadaj(Dogadaj.Predaj);
        }

        public void PredajCijeliProjekt(DateTime datumObrane)
        {
            DatumPredajeCijelogProjekta = datumObrane;
            ObradiDogadaj(Dogadaj.PredajSve);
        }

        public void OcijeniProjekt(int brojBodova)
        {
            BrojBodova = brojBodova;
            ObradiDogadaj(Dogadaj.Ocijeni);
        }
    }
}
