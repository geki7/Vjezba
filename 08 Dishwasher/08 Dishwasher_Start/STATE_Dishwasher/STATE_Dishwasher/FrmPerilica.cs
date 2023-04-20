using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static STATE_Dishwasher.Perilica;

namespace STATE_Dishwasher
{
    public partial class FrmPerilica : Form
    {
        Perilica perilica;
        public FrmPerilica()
        {
            InitializeComponent();
        }

        private void FrmPerilica_Load(object sender, EventArgs e)
        {
            perilica = new Perilica();
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
            btn60min.Enabled = false;
            btn90min.Enabled = false;
            btn120min.Enabled = false;
            btnStart.Enabled = false;
            btnPauzirajNastavi.Enabled = false;
            btnPranjeZavrsilo.Enabled = false;
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
            if (perilica.TrenutnoStanje == Stanje.Ugasena)
            {
                perilica.Upali();
                btn60min.Enabled = true;
                btn90min.Enabled = true;
                btn120min.Enabled = true;
            }
            else
            {
                perilica.Ugasi();
                btn60min.Enabled = false;
                btn90min.Enabled = false;
                btn120min.Enabled = false;
            }
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
        }

        private void btn60min_Click(object sender, EventArgs e)
        {
            perilica.OdaberiProgram(ProgramRada.Pranje_60min);
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
            if (perilica.TrenutnoStanje == Stanje.OdabranProgram)
            {
                perilica.Upali();
                btn60min.Enabled = false;
                btn90min.Enabled = false;
                btn120min.Enabled = false;
                btnStart.Enabled = true;
            }
        }

        private void btn90min_Click(object sender, EventArgs e)
        {
            perilica.OdaberiProgram(ProgramRada.Pranje_90min);
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
            if (perilica.TrenutnoStanje == Stanje.OdabranProgram)
            {
                perilica.Upali();
                btn60min.Enabled = false;
                btn90min.Enabled = false;
                btn120min.Enabled = false;
                btnStart.Enabled = true;
            }
        }

        private void btn120min_Click(object sender, EventArgs e)
        {
            perilica.OdaberiProgram(ProgramRada.Pranje_120min);
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
            if (perilica.TrenutnoStanje == Stanje.OdabranProgram)
            {
                perilica.Upali();
                btn60min.Enabled = false;
                btn90min.Enabled = false;
                btn120min.Enabled = false;
                btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            perilica.ZapocniPranje();
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
            if (perilica.TrenutnoStanje == Stanje.PranjeUToku)
            {
                perilica.Upali();
                btnStart.Enabled = false;
                btnPauzirajNastavi.Enabled = true;
            }
        }

        private void btnPauzirajNastavi_Click(object sender, EventArgs e)
        {
            perilica.PauzirajPranje();
            txtStatus.Text = perilica.TrenutnoStanje.ToString();

            if (perilica.TrenutnoStanje == Stanje.PranjeUToku)
            {
                perilica.PauzirajPranje();
                btnPranjeZavrsilo.Enabled = false;
            }
            else
            {
                perilica.NastaviPranje();
                btnPranjeZavrsilo.Enabled = true;
            }
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
        }

        private void btnPranjeZavrsilo_Click(object sender, EventArgs e)
        {
            perilica.PranjeZavrsilo();
            txtStatus.Text = perilica.TrenutnoStanje.ToString();

            if (perilica.TrenutnoStanje == Stanje.UMirovanju)
            {
                btnPranjeZavrsilo.Enabled = false;
                btnPauzirajNastavi.Enabled = false;
                btn60min.Enabled = true;
                btn90min.Enabled = true;
                btn120min.Enabled = true;
            }
            txtStatus.Text = perilica.TrenutnoStanje.ToString();
        }
    }
}
