using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RentACar
{
    partial class Vozilo
    {
        public string Registracija { get; set; }
        public string Model { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime DatumPredavanja { get; set; }
        public string PregledNapravio { get; set; }

        public bool UciniRaspolozivim_Enabled { get { return TrenutnoStanje == Stanje.NaPregledu; } }
        public bool Aktiviraj_Enabled { get { return TrenutnoStanje == Stanje.UKvaru; } }
        public bool Dektiviraj_Enabled { get { return TrenutnoStanje == Stanje.UUporabi; } }
        public bool RezervirajVozilo_Enabled { get { return TrenutnoStanje == Stanje.Raspoloziv; } }
        public bool PredajVozilo_Enabled { get { return TrenutnoStanje == Stanje.Rezerviran; } }
        public bool PregledajVozilo_Enabled { get { return TrenutnoStanje == Stanje.UUporabi; } }

        public Vozilo(string registracija, string model)
        {
            Registracija = registracija;
            Model = model;
            DefinirajMatricuPrijelaza();
        }

        public void RezervirajVozilo()
        {
            DatumRezervacije = DateTime.Now;
        }

        public void PredajVozilo()
        {
            DatumPredavanja = DateTime.Now;
        }

        public void PregledajVozilo(string pregledNapravio)
        {
            PregledNapravio = pregledNapravio;
        }

        public void AktivirajVozilo()
        {

        }

        public void DeaktivirajVozilo()
        {

        }

        public void UciniRaspolozivim()
        {

        }
    }
}
