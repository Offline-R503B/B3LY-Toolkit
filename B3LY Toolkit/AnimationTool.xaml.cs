using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace B3LY_Toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Thread taks = new Thread(WorkColors);
            taks.IsBackground = true;
            taks.Start();
        }

        private void WorkColors()
        {
            while (true)
            {
                Thread.Sleep(12);
                Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => {
                    Color randomColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
                    var z = new SolidColorBrush(randomColor);
                    RandomColor = z;
                

                }));
           
            }
    
        }

        private Random rnd = new Random();

        public Brush Cowler;

        public int ShitInt;

        public int RandomInt
        {
            get
            {
                int z = rnd.Next(0, 999);
                ShitInt = z;
                return ShitInt;
            }
            set
            {
                ShitInt = value;
                OnPropertyChanged("RandomInt");
            }


        }

        public Brush RandomColor
        {
            get
            {
                Color randomColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
                Cowler = new SolidColorBrush(randomColor);
                return Cowler;

            }
            set {
                Cowler = value;
                OnPropertyChanged("RandomColor"); }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
