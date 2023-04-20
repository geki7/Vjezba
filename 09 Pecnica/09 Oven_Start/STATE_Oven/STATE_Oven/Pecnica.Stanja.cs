using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_Oven
{
    partial class Pecnica
    {
        public enum Stanje
        {
            Upaljena, Ugasena, ProgramOdabran, PecenjeZapoceto, PecenjeZavrseno, HladenjeGotovo
        }

        public enum Dogadaj
        {
            Upali, Ugasi, Odaberi, Zapocni, Zavrseno, Ohladi
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

            strojStanja = new Action[6, 6]
            {
                {Ugasi,      null,       Odaberi,       null,       null,       null }, //Upaljena
                {null,      Upali,       null,       null,       null,       null }, //Ugasena
                {null,      null,       null,       Zapocni,       null,       null }, //ProgramOdabran
                {null,      null,       null,       null,       Zavrseno,       null }, //PecenjeZapoceto
                {null,      null,       null,       null,       null,       Ohladi }, //PecenjeZavrseno
                {Ugasi,      null,       null,       null,       null,       null } //HladenjeGotovo
            };
        }

        public void Upali()
        {
            TrenutnoStanje = Stanje.Upaljena;
        }

        public void Ugasi()
        {
            TrenutnoStanje = Stanje.Ugasena;
        }

        public void Odaberi()
        {
            TrenutnoStanje = Stanje.ProgramOdabran;
        }

        public void Zapocni()
        {
            TrenutnoStanje = Stanje.PecenjeZapoceto;
        }

        public void Zavrseno()
        {
            TrenutnoStanje = Stanje.PecenjeZavrseno;
        }

        public void Ohladi()
        {
            TrenutnoStanje = Stanje.HladenjeGotovo;
        }

        public void OdaberiProgram(ProgramRada program)
        {
            Program = program;
            ObradiDogadaj(Dogadaj.Odaberi);
        }
    }
}
