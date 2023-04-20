using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_Reklamacija
{
    partial class Reklamacija
    {
        public enum Stanje
        {
            Podnsena, URazmatranju, Odbijena, KonacnoOdbijena, Uvazena
        }
        public enum Dogadaj
        {
            DodjeliAgenta, Uvazi, Odbijena, Varti, KonacnoOdbij
        }

        public Stanje TrenutnoStanje { get; set; }
        public Action[,] strojStanja;

        public void ObradiDogadaj(Dogadaj dogadaj)
        {
            strojStanja[(int)TrenutnoStanje, (int)dogadaj].Invoke();
        }

        public void MatricaDogadaja()
        {
            TrenutnoStanje = Stanje.Podnsena;

            strojStanja = new Action[3, 5]
            {
                {Dodijeli,      null,       null,       null,       null }, //Podnesena
                {null,      Prihvati,       Odbij,       null,       null }, //URazmatranju
                {null,      null,       null,       VratiUPostupak,       KonačnoOdbij }  //Odbijena
            };
        }

        public void Dodijeli()
        {
            TrenutnoStanje = Stanje.URazmatranju;
        }

        public void DodijeliAgenta(string agent)
        {
            Agent = agent;
            ObradiDogadaj(Dogadaj.DodjeliAgenta);
        }

        public void Prihvati()
        {
            PosaljiObavijest("Vaša reklamacija je uvažena.");
            TrenutnoStanje = Stanje.Uvazena;
        }

        private void PosaljiObavijest(string poruka)
        {
            System.Windows.Forms.MessageBox.Show(poruka);
        }

        public void Odbij()
        {
            PosaljiObavijest("Vaša reklamacija je odbijena. Imate 3 dana za žalbu na tu odluku.");
            TrenutnoStanje = Stanje.Odbijena;
        }

        public void KonačnoOdbij()
        {
            PosaljiObavijest("Vaša reklamacija je konačno odbijena. Više nemate mogućnost žalbe.");
            TrenutnoStanje = Stanje.KonacnoOdbijena;
        }

        public void VratiUPostupak()
        {
            TrenutnoStanje = Stanje.Podnsena;
        }
    }
}
