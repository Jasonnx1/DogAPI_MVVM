using ApiConsumerDemo.ViewModels.Commands;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ApiConsumerDemo.ViewModels
{
    public class DogViewModel : BaseViewModel
    {

        private BitmapImage imageOne { get; set; }
        private BitmapImage imageTwo { get; set; }

        private BitmapImage LoadImageOne { get; set; }
        private BitmapImage LoadImageTwo { get; set; }

        public BitmapImage ImageOne
        {
            get => imageOne;
            set
            {
                imageOne = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage ImageTwo
        {
            get => imageTwo;
            set
            {
                imageTwo = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand ChangeDogsCommand { get; set; }
        public DogViewModel()
        {
            initValues();
        }

        private async void initValues()
        {
            ChangeDogsCommand = new AsyncCommand(ChangeDogs);

           await LoadDog();
           ImageOne = LoadImageOne;
           ImageTwo = LoadImageTwo;
        }

        private async Task LoadDog()
        {
            var dog = await DogProcessor.LoadDogImage();
            var uriSource = new Uri(dog.message, UriKind.Absolute);
            LoadImageOne = new BitmapImage(uriSource);

            dog = await DogProcessor.LoadDogImage();
            uriSource = new Uri(dog.message, UriKind.Absolute);
            LoadImageTwo = new BitmapImage(uriSource);

        }

        private async Task ChangeDogs()
        {
            await LoadDog();
            ImageOne = LoadImageOne;
            ImageTwo = LoadImageTwo;
        }


    }
}
