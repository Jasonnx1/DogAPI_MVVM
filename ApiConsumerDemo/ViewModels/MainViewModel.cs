using ApiConsumerDemo.ViewModels;
using ApiConsumerDemo.ViewModels.Commands;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ApiConsumerDemo
{
    public class MainViewModel : BaseViewModel
    {

        private int maxNumber { get; set; }
        private int currentNumber { get; set; }

        private bool next { get; set; }
        private bool previous { get; set; }



        public SunViewModel SunVm { get; set; }
        public DogViewModel DogVm { get; set; }
        public ComicViewModel ComicVm { get; set; }

        private BitmapImage comic { get; set; }

        public BitmapImage LoadComic { get; set; }
        public BitmapImage CurrentComic {
            get => comic;
            set
            {
                comic = value;
                OnPropertyChanged();
            }
        
        }
        public RelayCommand ShowSunInfoCommand { get; set; }
        public RelayCommand ShowDogWindowCommand { get; set; }
        public AsyncCommand NextComicCommand { get; set; }
        public AsyncCommand PreviousComicCommand { get; set; }

        public MainViewModel()
        {
            initValues();
        }

        private async void initValues()
        {
            maxNumber = 0;
            currentNumber = 0;

            SunVm = new SunViewModel();
            DogVm = new DogViewModel();
            ComicVm = new ComicViewModel();

            ShowSunInfoCommand = new RelayCommand(ShowSunInfo);
            ShowDogWindowCommand = new RelayCommand(ShowDogWindow);
            NextComicCommand = new AsyncCommand(NextComic, CanExecuteNext);
            PreviousComicCommand = new AsyncCommand(PreviousComic);


            await LoadImage();
            CurrentComic = LoadComic;
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
                next = false;
                previous = true;
            }

            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);

            LoadComic = new BitmapImage(uriSource,
            new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));

        }



        private async Task NextComic()
        {
            if (currentNumber < maxNumber)
            {
                
                if (currentNumber < maxNumber)
                {
                    currentNumber += 1;
                    await LoadImage(currentNumber);
                    CurrentComic = LoadComic;
                    previous = true;
                    PreviousComicCommand.RaiseCanExecuteChanged();

                    if(currentNumber == maxNumber)
                    {
                        next = false;
                        NextComicCommand.RaiseCanExecuteChanged();
                    }
                }

                

            }
        }

        private bool CanExecuteNext()
        {
            return next;
        }
        private bool CanExecutePrevious()
        {
            return previous;
        }

        private async Task PreviousComic()
        {
            
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                await LoadImage(currentNumber);
                CurrentComic = LoadComic;
                next = true;
                NextComicCommand.RaiseCanExecuteChanged();

                if(currentNumber == 1)
                {
                    previous = false;
                    PreviousComicCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private void ShowSunInfo(object o)
        {
            SunInfo sunInfo = new SunInfo(SunVm);
            sunInfo.Show();
        }

        private void ShowDogWindow(object o)
        {
            DogWindow dogWin = new DogWindow(DogVm);
            dogWin.Show();
        }

    }
}
