using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static STATE_Oven.Pecnica;

namespace STATE_Oven
{
    public partial class FrmPecnica : Form
    {
        Pecnica pecnica;
        public FrmPecnica()
        {
            InitializeComponent();
        }

        private void FrmPerilica_Load(object sender, EventArgs e)
        {
            pecnica = new Pecnica();
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();
            btn150C.Enabled = false;
            btn180C.Enabled = false;
            btn200C.Enabled = false;
            btnStart.Enabled = false;
            btnIstekloVrijeme.Enabled = false;
            btnOhladiPecnicu.Enabled = false;
        }



        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (pecnica.TrenutnoStanje == Stanje.Ugasena)
            {
                pecnica.Upali();
                btn150C.Enabled = true;
                btn180C.Enabled = true;
                btn200C.Enabled = true;
            }
            else
            {
                pecnica.Ugasi();
                btn150C.Enabled = false;
                btn180C.Enabled = false;
                btn200C.Enabled = false;
            }
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();
        }

        private void btn150C_Click(object sender, EventArgs e)
        {
            pecnica.OdaberiProgram(ProgramRada.Pečenje_150C);
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();

            if (pecnica.TrenutnoStanje == Stanje.ProgramOdabran)
            {
                btnOnOff.Enabled = false;
                btn150C.Enabled = false;
                btn180C.Enabled = false;
                btn200C.Enabled = false;
                btnStart.Enabled = true;
                btnIstekloVrijeme.Enabled = false;
            }
        }

        private void btn180C_Click(object sender, EventArgs e)
        {
            pecnica.OdaberiProgram(ProgramRada.Pečenje_180C);
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();

            if (pecnica.TrenutnoStanje == Stanje.ProgramOdabran)
            {
                btnOnOff.Enabled = false;
                btn150C.Enabled = false;
                btn180C.Enabled = false;
                btn200C.Enabled = false;
                btnStart.Enabled = true;
                btnIstekloVrijeme.Enabled = false;
            }
        }

        private void btn200C_Click(object sender, EventArgs e)
        {
            pecnica.OdaberiProgram(ProgramRada.Pečenje_200C);
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();

            if (pecnica.TrenutnoStanje == Stanje.ProgramOdabran)
            {
                btnOnOff.Enabled = false;
                btn150C.Enabled = false;
                btn180C.Enabled = false;
                btn200C.Enabled = false;
                btnStart.Enabled = true;
                btnIstekloVrijeme.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pecnica.Zapocni();
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();

            if (pecnica.TrenutnoStanje == Stanje.PecenjeZapoceto)
            {
                btn150C.Enabled = true;
                btn180C.Enabled = true;
                btn200C.Enabled = true;
                btnStart.Enabled = false;
                btnIstekloVrijeme.Enabled = true;
            }
        }

        private void btnIstekloVrijeme_Click(object sender, EventArgs e)
        {
            pecnica.Zavrseno();
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();

            if (pecnica.TrenutnoStanje == Stanje.PecenjeZavrseno)
            {
                btn150C.Enabled = false;
                btn180C.Enabled = false;
                btn200C.Enabled = false;
                btnIstekloVrijeme.Enabled = false;
                btnOhladiPecnicu.Enabled = true;
            }
        }

        private void btnOhladiPecnicu_Click(object sender, EventArgs e)
        {
            pecnica.Ohladi();
            txtStatus.Text = pecnica.TrenutnoStanje.ToString();

            btnOhladiPecnicu.Enabled = false;
            btnOnOff.Enabled = true;
        }
    }
}
