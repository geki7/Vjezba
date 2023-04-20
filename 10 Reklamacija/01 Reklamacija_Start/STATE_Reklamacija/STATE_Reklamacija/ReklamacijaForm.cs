using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static STATE_Reklamacija.Reklamacija;

namespace STATE_Reklamacija
{
    public partial class ReklamacijaForm : Form
    {
        private Reklamacija _reklamacija;
        public ReklamacijaForm()
        {
            InitializeComponent();
        }

        private void ReklamacijaForm_Load(object sender, EventArgs e)
        {
            _reklamacija = new Reklamacija
            {
                Id = 1112,
                Opis = "Tablet je stigao sa puknutim ekranom..."
            };

            txtIdReklamacije.Text = _reklamacija.Id.ToString();
            txtOpisReklamacije.Text = _reklamacija.Opis;
            txtStatusReklamacije.Text = _reklamacija.TrenutnoStanje.ToString();

            radOpravdana.Enabled = false;
            rbNeutemeljen.Enabled = false;
            btnOcijeni.Enabled = false;

            rbPristigla.Enabled = false;
            rbNijePristigla.Enabled = false;
            btnObradiŽalbu.Enabled = false;
        }

        private void btnDodijeliAgenta_Click(object sender, EventArgs e)
        {
            _reklamacija.DodijeliAgenta(txtAgent.Text);
            txtStatusReklamacije.Text = _reklamacija.TrenutnoStanje.ToString();

            if (_reklamacija.TrenutnoStanje == Stanje.URazmatranju)
            {
                txtAgent.Enabled = false;
                btnDodijeliAgenta.Enabled = false;

                radOpravdana.Enabled = true;
                rbNeutemeljen.Enabled = true;
                btnOcijeni.Enabled = true;
            }
        }

        private void btnOcijeni_Click(object sender, EventArgs e)
        {
            if (radOpravdana.Checked == true)
            {
                _reklamacija.Prihvati();
            }
            else
            {
                _reklamacija.Odbij();
            }
            if (_reklamacija.TrenutnoStanje == Stanje.Uvazena)
            {
                radOpravdana.Enabled = false;
                rbNeutemeljen.Enabled = false;
                btnOcijeni.Enabled = false;
            }

            if (_reklamacija.TrenutnoStanje == Stanje.Odbijena)
            {
                radOpravdana.Enabled = false;
                rbNeutemeljen.Enabled = false;
                btnOcijeni.Enabled = false;

                rbPristigla.Enabled = true;
                rbNijePristigla.Enabled = true;
                btnObradiŽalbu.Enabled = true;
            }

            txtStatusReklamacije.Text = _reklamacija.TrenutnoStanje.ToString();
        }

        private void btnObradiŽalbu_Click(object sender, EventArgs e)
        {
            if (rbPristigla.Checked == true)
            {
                _reklamacija.VratiUPostupak();
            }
            else
            {
                _reklamacija.KonačnoOdbij();
            }
            if (_reklamacija.TrenutnoStanje == Stanje.KonacnoOdbijena)
            {
                rbPristigla.Enabled = false;
                rbNijePristigla.Enabled = false;
                btnObradiŽalbu.Enabled = false;
            }
            if (_reklamacija.TrenutnoStanje == Stanje.Podnsena)
            {
                rbPristigla.Enabled = false;
                rbNijePristigla.Enabled = false;
                btnObradiŽalbu.Enabled = false;

                btnDodijeliAgenta.Enabled = true;
                txtAgent.Enabled = true;
            }

            txtStatusReklamacije.Text = _reklamacija.TrenutnoStanje.ToString();
        }
    }
}
