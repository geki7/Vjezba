using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static STATE_ServisniZahtjev.ServisniZahtjev;

namespace STATE_ServisniZahtjev
{
    public partial class FrmServisniZahtjev : Form
    {
        private ServisniZahtjev _servisniZahtjev;
        public FrmServisniZahtjev()
        {
            InitializeComponent();
        }

        private void FrmServisniZahtjev_Load(object sender, EventArgs e)
        {
            _servisniZahtjev = new ServisniZahtjev();
            txtStatusZahtjeva.Text = _servisniZahtjev.TrenutnoStanje.ToString();
            btnZaprimiZahtjev.Enabled = false;
            btnZapocniServisiranje.Enabled = false;
            btnZatvoriZahtjev.Enabled = false;
            dtpDatumPocetka.Enabled = false;
            dtpDatumZaprimanja.Enabled = false;
            dtpDatumZatvaranja.Enabled = false;
        }

        private void btnPodnesiZahtjev_Click(object sender, EventArgs e)
        {
            _servisniZahtjev.PodnesiZahtjev(txtOpisKvara.Text, dtpDatumIzrade.Value);
            txtStatusZahtjeva.Text = _servisniZahtjev.TrenutnoStanje.ToString();

            if(_servisniZahtjev.TrenutnoStanje == Stanje.Podnesen)
            {
                btnPodnesiZahtjev.Enabled = false;
                dtpDatumIzrade.Enabled = false;
                txtOpisKvara.Enabled = false;
                txtStatusZahtjeva.Enabled = false;
                dtpDatumZaprimanja.Enabled = true;
                btnZaprimiZahtjev.Enabled = true;
                btnOdbijZahtjev.Enabled = true;
            }
        }

        private void btnZaprimiZahtjev_Click(object sender, EventArgs e)
        {
            _servisniZahtjev.ZaprimiZahtjev(dtpDatumZaprimanja.Value);
            txtStatusZahtjeva.Text = _servisniZahtjev.TrenutnoStanje.ToString();

            if (_servisniZahtjev.TrenutnoStanje == Stanje.Zaprmiljen)
            {
                btnOdbijZahtjev.Enabled = false;
                btnZaprimiZahtjev.Enabled = false;
                dtpDatumZaprimanja.Enabled = false;
                dtpDatumPocetka.Enabled = true;
                btnZapocniServisiranje.Enabled = true;
            }
        }

        private void btnZapocniServisiranje_Click(object sender, EventArgs e)
        {
            _servisniZahtjev.ZapocniServisiranje(dtpDatumPocetka.Value);
            txtStatusZahtjeva.Text = _servisniZahtjev.TrenutnoStanje.ToString();

            if (_servisniZahtjev.TrenutnoStanje == Stanje.UPostupku)
            {
                dtpDatumPocetka.Enabled = false;
                btnZapocniServisiranje.Enabled = false;
                dtpDatumZatvaranja.Enabled = true;
                btnZatvoriZahtjev.Enabled = true;
            }
        }

        private void btnZatvoriZahtjev_Click(object sender, EventArgs e)
        {
            _servisniZahtjev.ZatvoriZahtjev(dtpDatumZatvaranja.Value);
            txtStatusZahtjeva.Text = _servisniZahtjev.TrenutnoStanje.ToString();

            if (_servisniZahtjev.TrenutnoStanje == Stanje.ZahtjevZatvoren)
            {
                dtpDatumZatvaranja.Enabled = false;
                btnZatvoriZahtjev.Enabled = false;
            }
        }

        private void btnOdbijZahtjev_Click(object sender, EventArgs e)
        {
            _servisniZahtjev.OdbijZahtjev();
            txtStatusZahtjeva.Text = _servisniZahtjev.TrenutnoStanje.ToString();

            if (_servisniZahtjev.TrenutnoStanje == Stanje.Odbijen)
            {
                btnOdbijZahtjev.Enabled = false;
                btnPodnesiZahtjev.Enabled = false;
                dtpDatumIzrade.Enabled = false;
                txtOpisKvara.Enabled = false;
                txtStatusZahtjeva.Enabled = false;
                dtpDatumZaprimanja.Enabled = false;
                btnZaprimiZahtjev.Enabled = false;
            }
        }
    }
}
