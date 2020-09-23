using DemoLibrary;
using System;
using System.Net.Cache;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ApiConsumerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Source : https://www.youtube.com/watch?v=aWePkE2ReGw&t=4s&ab_channel=IAmTimCorey
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            DataContext = new MainViewModel();
        }


    }
}
