using System.ComponentModel;
using System.Runtime.CompilerServices;
using OniTemplate.Annotations;
using OniTemplate.Extensions;

namespace OniTemplate.Editor.Model
{
    public class TileProperty : INotifyPropertyChanged
    {
        public string Element { get; set; }

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

        private double _massGrams;
        public double MassGrams
        {
            get => _massGrams;
            set
            {
                _massGrams = value;
                OnPropertyChanged(nameof(MassGrams));
            }
        }

        public static TileProperty NullTileProperty()
        {
            var prop = new TileProperty();
            prop.Element = "null";
            prop.TemperatureKelvin = 300;
            prop.MassGrams = 1000;
            prop.DiseaseCount = null;
            prop.DiseaseName = null;
            return prop;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
