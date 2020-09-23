using ApiConsumerDemo.ViewModels.Commands;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumerDemo.ViewModels
{
    public class SunViewModel : BaseViewModel
    {

        private string leveSoleil { get; set; }
        private string coucheSoleil { get; set; }

        private string LoadLeve { get; set; }
        private string LoadCouche { get; set; }

        public string LeveSoleil
        {
            get => leveSoleil;
            set
            {
                leveSoleil = value;
                OnPropertyChanged();
            }
        }

        public string CoucheSoleil
        {
            get => coucheSoleil;
            set
            {
                coucheSoleil = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand SunInfoCommand { get; set; }

        public SunViewModel()
        {

            SunInfoCommand = new AsyncCommand(SunInfo);

        }

        private async Task LoadInfo()
        {

            var sunInfo = await SunProcessor.LoadSunInformation();
            LoadLeve = $"Le levée du Soleil sera à {sunInfo.Sunrise.ToLocalTime().ToShortTimeString()}";
            LoadCouche = $"Le couché du Soleil sera à {sunInfo.Sunset.ToLocalTime().ToShortTimeString()}";

        }

        private async Task SunInfo()
        {

            await LoadInfo();
            LeveSoleil = LoadLeve;
            CoucheSoleil = LoadCouche;

        }






    }
}
