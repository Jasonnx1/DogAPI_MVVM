using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using ApiConsumerDemo.ViewModels;

namespace ApiConsumerDemo
{
    /// <summary>
    /// Interaction logic for DogWindow.xaml
    /// </summary>
    public partial class DogWindow : Window
    {
        public DogWindow(DogViewModel vm)
        {       
            InitializeComponent();
            DataContext = vm;      
        }

    }
}
