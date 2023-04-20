using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static STATE_RadniNalog.RadniNalog;

namespace STATE_RadniNalog
{
    public partial class RadniNalogForm : Form
    {
        private RadniNalog _radniNalog;
        public RadniNalogForm()
        {
            InitializeComponent();  
        }

        private void RadniNalogForm_Load(object sender, EventArgs e)
        {
            _radniNalog = new RadniNalog();
            txtStatus.Text = _radniNalog.TrenutnoStanje.ToString();
            btnPredajNalog.Enabled = false;
            btnZapocniProizvodnju.Enabled = false;
            btnDovrsiProizvodnju.Enabled = false;
            dtpDatumDovrsetka.Enabled = false;
            dtpDatumPocetka.Enabled = false;
            dtpDatumPredaje.Enabled = false;
        }

        private void btnZakljucaj_Click(object sender, EventArgs e)
        {
            _radniNalog.ZakljucajNalog(txtOpis.Text);
            txtDatumKreiranja.Text = _radniNalog.DatumKreiranja.ToString();
            txtStatus.Text = _radniNalog.TrenutnoStanje.ToString();

            if(_radniNalog.TrenutnoStanje == Stanje.Zakljucan)
            {
                btnZakljucaj.Enabled = false;
                btnOtkaziNalog.Enabled = true;
                btnPredajNalog.Enabled = true;
                dtpDatumPredaje.Enabled = true;
                txtOpis.Enabled = false;
            }
        }

        private void btnPredajNalog_Click(object sender, EventArgs e)
        {
            _radniNalog.PredajUProizvodnju(dtpDatumPredaje.Value);
            txtStatus.Text = _radniNalog.TrenutnoStanje.ToString();

            if (_radniNalog.TrenutnoStanje == Stanje.PredanUProizvodnju)
            {
                btnZakljucaj.Enabled = false;
                btnOtkaziNalog.Enabled = false;
                btnPredajNalog.Enabled = false;
                dtpDatumPredaje.Enabled = false;
                dtpDatumPocetka.Enabled = true;
                btnZapocniProizvodnju.Enabled = true;
            }
        }

        private void btnZapocniProizvodnju_Click(object sender, EventArgs e)
        {
            _radniNalog.ZapocniProizvodnju(dtpDatumPocetka.Value);
            txtStatus.Text = _radniNalog.TrenutnoStanje.ToString();

            if (_radniNalog.TrenutnoStanje == Stanje.ZapocetaProizvodnja)
            {
                dtpDatumPocetka.Enabled = false;
                btnZapocniProizvodnju.Enabled = false;
                dtpDatumDovrsetka.Enabled = true;
                btnDovrsiProizvodnju.Enabled = true;
            }
        }

        private void btnDovrsiProizvodnju_Click(object sender, EventArgs e)
        {
            _radniNalog.DovrsiProizvodnju(dtpDatumDovrsetka.Value);
            txtStatus.Text = _radniNalog.TrenutnoStanje.ToString();

            if (_radniNalog.TrenutnoStanje == Stanje.DovrsenaProizvodnja)
            {
                dtpDatumDovrsetka.Enabled = false;
                btnDovrsiProizvodnju.Enabled = false;
            }
        }

        private void btnOtkaziNalog_Click(object sender, EventArgs e)
        {
            _radniNalog.Otkazi();
            txtStatus.Text = _radniNalog.TrenutnoStanje.ToString();

            if (_radniNalog.TrenutnoStanje == Stanje.Otkazan)
            {
                btnZakljucaj.Enabled = true;
                btnOtkaziNalog.Enabled = false;
                btnPredajNalog.Enabled = false;
                dtpDatumPredaje.Enabled = false;
                btnZakljucaj.Enabled = false;
            }
        }
    }
}
