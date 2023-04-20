using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_Dishwasher
{
    partial class Perilica
    {
        public enum Stanje
        {
            Ugasena, UMirovanju, OdabranProgram, PranjeUToku, Pauzirano
        }
        
        public enum Dogadaj
        {
            Upali, Ugasi, OdaberiProgram, ZapocniPranje, PranjeZavrsilo, PauzirajPranje, NastaviPranje
        }

        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDogadaj(Dogadaj dogadaj)
        {
            strojStanja[(int)TrenutnoStanje, (int)dogadaj].Invoke();
        }

        public void MatricaDogadaja()
        {
            TrenutnoStanje = Stanje.Ugasena;

            strojStanja = new Action[5, 7]
            {
               {Upali,      null,      null,       null,       null,       null,       null}, //Ugasena
               {null,      Ugasi,      OdaberiProgram,       null,       null,       null,       null}, //UMirovanju
               {null,      null,       ZapocniPranje,       null,       null,       null,       null}, //OdabranProgram
               {null,      null,       null,       null,       PranjeZavrsilo,       PauzirajPranje,       null}, //PranjeUtoku
               {null,      null,       null,       null,       null,       NastaviPranje,       null}  //Pauzirano
            };
        }
        public void OdaberiProgram(ProgramRada odabraniProgram)
        {
            Program = odabraniProgram;
            ObradiDogadaj(Dogadaj.OdaberiProgram);
        }
        
        public void Upali()
        {
            TrenutnoStanje = Stanje.UMirovanju;
        }

        public void Ugasi()
        {
            TrenutnoStanje = Stanje.Ugasena;
        }

        public void OdaberiProgram()
        {
            TrenutnoStanje = Stanje.OdabranProgram;
        }

        public void ZapocniPranje()
        {
            TrenutnoStanje = Stanje.PranjeUToku;
        }

        public void NastaviPranje()
        {
            TrenutnoStanje = Stanje.PranjeUToku;
        }

        public void PauzirajPranje()
        {
            TrenutnoStanje = Stanje.Pauzirano;
        }

        public void PranjeZavrsilo()
        {
            TrenutnoStanje = Stanje.UMirovanju;
        }
    }
}
