using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

namespace VanillaWPF.Controls.Thermometer
{
    /// <summary>
    /// Interaction logic for Thermometer.xaml
    /// </summary>
    public partial class Thermometer : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register("Temperature", typeof(double), typeof(Thermometer), new PropertyMetadata(36.6));
        public double Temperature
        {
            get { return (double)GetValue(TemperatureProperty); }
            set
            {
                SetValue(TemperatureProperty, value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isCelsius = true;
        public bool IsCelsius
        {
            get => isCelsius;
            set
            {
                isCelsius = value;
                OnPropertyChanged(nameof(IsCelsius));
                OnPropertyChanged(nameof(MaxTemperatureStr));
                OnPropertyChanged(nameof(MinTemperatureStr));
                OnPropertyChanged(nameof(TemperatureText));
            }
        }

        private double minTemperature = -30.0;
        public double MinTemperature
        {
            get => minTemperature;
            set
            {
                minTemperature = value;
                temperatureStep = (temperatureTube.ActualHeight - (bulb.ActualHeight / 2)) / (MaxTemperature - MinTemperature);
                OnPropertyChanged(nameof(MinTemperature));
                OnPropertyChanged(nameof(MinTemperatureStr));

            }
        }

        private double maxTemperature = 50.0;
        public double MaxTemperature
        {
            get => maxTemperature;
            set
            {
                maxTemperature = value;
                temperatureStep = (temperatureTube.ActualHeight - (bulb.ActualHeight / 2)) / (MaxTemperature - MinTemperature);
                OnPropertyChanged(nameof(MaxTemperature));
                OnPropertyChanged(nameof(MaxTemperatureStr));

            }
        }

        public string MaxTemperatureStr { get => $"{(int)MaxTemperature}°" + (IsCelsius ? "C" : "F"); }
        public string MinTemperatureStr { get => $"{(int)MinTemperature}°" + (IsCelsius ? "C" : "F"); }
        public string TemperatureText { get => $"{(int)Math.Round( Temperature, 2)}°" + (IsCelsius ? "C" : "F"); }

        private double temperatureStep = 1;
        public double TemperatureHeight
        {
            get => (Temperature - minTemperature) * temperatureStep + (bulb.ActualHeight / 2);
        }

        public Thermometer()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            switch (e.Property.Name)
            {
                case "ActualHeight":
                    {
                        temperatureStep = (temperatureTube.ActualHeight - (bulb.ActualHeight / 2)) / (MaxTemperature - MinTemperature);
                        OnPropertyChanged(nameof(TemperatureHeight));
                    }
                    break;
                case "Temperature":
                    OnPropertyChanged(nameof(TemperatureHeight));
                    OnPropertyChanged(nameof(TemperatureText));
                    break;
            }
        }
    }
}
