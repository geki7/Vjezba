using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static STATE_PI_Projekt.Projekt;

namespace STATE_PI_Projekt
{
    public partial class FrmProjekt : Form
    {
        private Projekt _projekt;
        public FrmProjekt()
        {
            InitializeComponent();
            btnOdbijProjekt.Enabled = false;
            btnOznaciKaoObranjen.Enabled = false;
            btnPredajProjekt.Enabled = false;
            btnPrihvatiProjekt.Enabled = false;
            btnZabiljeziTemu.Enabled = false;
            btnZakaziObranu.Enabled = false;
        }

        private void FrmProjekt_Load(object sender, EventArgs e)
        {
            _projekt = new Projekt();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();
        }

        private void btnZabiljeziTemu_Click(object sender, EventArgs e)
        {
            _projekt.ZabiljeziTemu(txtOpisProjekta.Text, txtOznakaTima.Text);
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if(_projekt.TrenutnoStanje == Stanje.TemaPrijavljena)
            {
                btnPredajProjekt.Enabled = true;
                dtpDatumPredaje.Enabled = true;
                txtOpisProjekta.Enabled = false;
                txtOznakaTima.Enabled = false;
                btnZabiljeziTemu.Enabled = false;
            }
        }

        private void btnPredajProjekt_Click(object sender, EventArgs e)
        {
            _projekt.PredajProjekt(dtpDatumPredaje.Value);
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if(_projekt.TrenutnoStanje == Stanje.PredanProjekt)
            {
                btnPredajProjekt.Enabled = false;
                dtpDatumPredaje.Enabled = false;
                btnOdbijProjekt.Enabled = true;
                btnPrihvatiProjekt.Enabled = true;
            }
        }

        private void btnOdbijProjekt_Click(object sender, EventArgs e)
        {
            _projekt.Odbij();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if(_projekt.TrenutnoStanje == Stanje.TemaPrijavljena)
            {
                btnPredajProjekt.Enabled = true;
                dtpDatumPredaje.Enabled = true;
                txtOpisProjekta.Enabled = false;
                txtOznakaTima.Enabled = false;
                btnZabiljeziTemu.Enabled = false;
                btnPrihvatiProjekt.Enabled = false;
                btnOdbijProjekt.Enabled = false;
            }
        }

        private void btnPrihvatiProjekt_Click(object sender, EventArgs e)
        {
            _projekt.Prihvati();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.PrihvacenProjekt)
            {
                btnPredajProjekt.Enabled = false;
                dtpDatumPredaje.Enabled = false;
                btnOdbijProjekt.Enabled = false;
                btnPrihvatiProjekt.Enabled = false;
                dtpDatumObrane.Enabled = true;
                btnZakaziObranu.Enabled = true;
            }
        }

        private void btnZakaziObranu_Click(object sender, EventArgs e)
        {
            _projekt.ZakažiObranu(dtpDatumObrane.Value);
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.ZakazanaObrana)
            {
                btnOznaciKaoObranjen.Enabled = true;
                dtpDatumObrane.Enabled = false;
                btnZakaziObranu.Enabled = false;
            }
        }

        private void btnOznaciKaoObranjen_Click(object sender, EventArgs e)
        {
            _projekt.Obranjeno();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.ObranjenProjekt)
            {
                btnOznaciKaoObranjen.Enabled = false;
            }
        }
    }
}
