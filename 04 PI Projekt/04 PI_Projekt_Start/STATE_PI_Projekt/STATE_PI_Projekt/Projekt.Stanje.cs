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
            PredanProjekt,
            PrihvacenProjekt,
            ZakazanaObrana,
            ObranjenProjekt
        }
        public enum Dogadaj
        {
            ZabiljeziTemu,
            PredajProjekt,
            OdbijProjekt,
            PrihvatiProjekt,
            ProjektProvjeren,
            ZakaziObranu,
            Obranjeno
        }
        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDogadaj(Dogadaj dogadaj)
        {
            strojStanja[(int)TrenutnoStanje, (int)dogadaj].Invoke();
        }

        public void DefinirajMatricuStanja()
        {
            TrenutnoStanje = Stanje.TemaNijePrijavljena;
            strojStanja = new Action[5, 7]
            {
                { ZabiljeziTemu, null, null, null, null, null, null}, //TemaNijePrijavljena
                { null, Predaj, null, null, null, null, null}, //TemaPrijavljena
                { null, null, Odbij, Prihvati, null, null, null}, //PredanProjekt
                { null, null, null, null, null, ZakaziObranu, null}, //PrihvacenProjekt
                { null, null, null, null, null, null, Obranjeno}  //ZakazanaObrana
            };
        }

        public void ZabiljeziTemu(string opisTeme, string oznakaTima)
        {
            OpisTeme = opisTeme;
            OznakaTima = oznakaTima;
            ObradiDogadaj(Dogadaj.ZabiljeziTemu);
        }

        public void ZabiljeziTemu()
        {
            TrenutnoStanje = Stanje.TemaPrijavljena;
        }

        public void PredajProjekt(DateTime datumPredaje)
        {
            DatumPredaje = datumPredaje;
            ObradiDogadaj(Dogadaj.PredajProjekt);
        }
        
        public void Predaj()
        {
            TrenutnoStanje = Stanje.PredanProjekt;
        }

        public void Odbij()
        {
            TrenutnoStanje = Stanje.TemaPrijavljena;
        }

        public void Prihvati()
        {
            TrenutnoStanje = Stanje.PrihvacenProjekt;
        }

        public void ZakaziObranu()
        {
            TrenutnoStanje = Stanje.ZakazanaObrana;
        }

        public void Obranjeno()
        {
            TrenutnoStanje = Stanje.ObranjenProjekt;
        }

        public void ZakažiObranu(DateTime datumObrane)
        {
            DatumObrane = datumObrane;
            ObradiDogadaj(Dogadaj.ZakaziObranu);
        }
    }
}
