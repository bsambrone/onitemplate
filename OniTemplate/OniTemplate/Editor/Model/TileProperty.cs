using System.ComponentModel;
using System.Runtime.CompilerServices;
using OniTemplate.Annotations;
using OniTemplate.Extensions;

namespace OniTemplate.Editor.Model
{
    public class TileProperty : INotifyPropertyChanged
    {
        private double _kelvin;
        public double TemperatureKelvin
        {
            get => _kelvin;
            set
            {
                _kelvin = value;
                TemperatureCelcius = _kelvin.ToCelcius();
                TemperatureFarenheight = _kelvin.ToFarenheight();
                OnPropertyChanged(nameof(TemperatureKelvin));
            }
        }

        private double _celcius;
        public double TemperatureCelcius
        {
            get => _celcius;
            set
            {
                _celcius = value;
                OnPropertyChanged(nameof(TemperatureCelcius));
            }
        }

        private double _farenheight;
        public double TemperatureFarenheight
        {
            get => _farenheight;
            set
            {
                _farenheight = value;
                OnPropertyChanged(nameof(TemperatureFarenheight));
            }
        }

        private string _diseaseName;
        public string DiseaseName
        {
            get => _diseaseName;
            set
            {
                _diseaseName = value;
                OnPropertyChanged(nameof(DiseaseName));
            }
        }

        private int? _diseaseCount;
        public int? DiseaseCount
        {
            get => _diseaseCount;
            set
            {
                _diseaseCount = value;
                OnPropertyChanged(nameof(DiseaseCount));
            }
        }

        private double _massKiloGrams;
        public double MassKiloGrams
        {
            get => _massKiloGrams;
            set
            {
                _massKiloGrams = value;
                OnPropertyChanged(nameof(MassKiloGrams));
            }
        }

        private double _hitpoints;
        public double HitPoints
        {
            get => _hitpoints;
            set
            {
                _hitpoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        private double _maturity;
        public double Maturity
        {
            get => _maturity;
            set
            {
                _maturity = value;
                OnPropertyChanged(nameof(MassKiloGrams));
            }
        }

        public TileProperty()
        {
            TemperatureKelvin = 300;
            MassKiloGrams = 1000;
            DiseaseCount = null;
            DiseaseName = null;
            Maturity = 1;
            HitPoints = 25;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
