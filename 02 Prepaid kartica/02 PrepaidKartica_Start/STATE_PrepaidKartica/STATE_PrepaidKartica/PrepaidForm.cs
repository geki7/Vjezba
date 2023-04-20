using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STATE_PrepaidKartica
{
    public partial class PrepaidForm : Form
    {
        private PrepaidKartica _kartica;
        public PrepaidForm()
        {
            InitializeComponent();
        }

        private void PrepaidForm_Load(object sender, EventArgs e)
        {
            _kartica = new PrepaidKartica("HR12312414213");
            txtSerijskiBroj.Text = _kartica.SerijskiBroj;
            Osvjezi();
        }

        private void Osvjezi()
        {
            txtIznosUplate.Enabled = _kartica.Uplati_Enabled;
            btnUplati.Enabled = _kartica.Uplati_Enabled;

            txtIznosIsplate.Enabled = _kartica.Isplati_Enabled;
            btnIsplati.Enabled = _kartica.Isplati_Enabled;

            btnAktiviraj.Enabled = _kartica.Aktiviraj_Enabled;
            txtIznos.Text = _kartica.Iznos.ToString();

            Application.DoEvents();
        }

        private void btnAktiviraj_Click(object sender, EventArgs e)
        {
            _kartica.Aktiviraj();
            _kartica.ObradiDogadaja(PrepaidKartica.Dogadaj.ProdajaKartice);
            Osvjezi();
        }

        private void btnUplati_Click(object sender, EventArgs e)
        {
            double iznosUplate = double.Parse(txtIznosUplate.Text);
            _kartica.Uplati(iznosUplate);
            txtIznosUplate.Clear();
            _kartica.ObradiDogadaja(PrepaidKartica.Dogadaj.UplacenaSredstva);
            Osvjezi();
        }

        private void btnIsplati_Click(object sender, EventArgs e)
        {
            double iznosIsplate = double.Parse(txtIznosIsplate.Text);
            _kartica.Isplati(iznosIsplate);
            txtIznosIsplate.Clear();
            _kartica.ObradiDogadaja(PrepaidKartica.Dogadaj.ImaSredstava);
            _kartica.ObradiDogadaja(PrepaidKartica.Dogadaj.NemaSredstava);
            Osvjezi();
        }
    }
}
