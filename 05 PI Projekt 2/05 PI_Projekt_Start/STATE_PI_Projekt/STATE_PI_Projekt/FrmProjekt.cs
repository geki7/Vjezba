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
        }

        private void FrmProjekt_Load(object sender, EventArgs e)
        {
            _projekt = new Projekt();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();
            btnOcijeniProjekt.Enabled = false;
            btnOdbijTemu.Enabled = false;
            btnPredajCijeliProjekt.Enabled = false;
            btnPredajPrvuFazu.Enabled = false;
            btnPrihvatiTemu.Enabled = false;
            dtpDatumPredajeCijelogProjekta.Enabled = false;
            dtpDatumPrveFaze.Enabled = false;
            txtBrojBodova.Enabled = false;
        }

        private void btnZabiljeziTemu_Click(object sender, EventArgs e)
        {
            _projekt.ZabiljeziTemu(txtOpisTeme.Text, txtOznakaTima.Text);
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.TemaPrijavljena)
            {
                txtOznakaTima.Enabled = false;
                txtOpisTeme.Enabled = false;
                btnZabiljeziTemu.Enabled = false;
                btnOdbijTemu.Enabled = true;
                btnPrihvatiTemu.Enabled = true;
            }
        }

        private void btnPredajPrvuFazu_Click(object sender, EventArgs e)
        {
            _projekt.PredajPrvuFazu(dtpDatumPrveFaze.Value);
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.PredanaPrvaFaza)
            {
                dtpDatumPrveFaze.Enabled = false;
                btnPredajPrvuFazu.Enabled = false;
                btnPredajCijeliProjekt.Enabled = true;
                dtpDatumPredajeCijelogProjekta.Enabled = true;
            }
        }

        private void btnOdbijTemu_Click(object sender, EventArgs e)
        {
            _projekt.Odbij();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.TemaNijePrijavljena)
            {
                txtOznakaTima.Enabled = false;
                txtOpisTeme.Enabled = false;
                btnZabiljeziTemu.Enabled = true;
                btnOdbijTemu.Enabled = false;
                btnPrihvatiTemu.Enabled = false;
            }
        }

        private void btnPrihvatiTemu_Click(object sender, EventArgs e)
        {
            _projekt.Prihvati();
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.TemaPrihvacena)
            {
                dtpDatumPrveFaze.Enabled = true;
                btnPredajPrvuFazu.Enabled = true;
                btnOdbijTemu.Enabled = false;
                btnPrihvatiTemu.Enabled = false;
            }
        }

        private void btnPredajCijeliProjekt_Click(object sender, EventArgs e)
        {
            _projekt.PredajCijeliProjekt(dtpDatumPredajeCijelogProjekta.Value);
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.PredanProjekt)
            {
                dtpDatumPredajeCijelogProjekta.Enabled = false;
                btnPredajCijeliProjekt.Enabled = false;
                txtBrojBodova.Enabled = true;
                btnOcijeniProjekt.Enabled = true;
            }
        }

        private void btnOcijeni_Click(object sender, EventArgs e)
        {
            _projekt.OcijeniProjekt(int.Parse(txtBrojBodova.Text));
            txtStatus.Text = _projekt.TrenutnoStanje.ToString();

            if (_projekt.TrenutnoStanje == Stanje.ProjektOcijenjen)
            {
                txtBrojBodova.Enabled = false;
                btnOcijeniProjekt.Enabled = false;
            }
        }
    }
}
