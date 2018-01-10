using System.ComponentModel;
using System.Runtime.CompilerServices;
using OniTemplate.Annotations;

namespace OniTemplate.Editor.Model
{
    public class TileEntity : INotifyPropertyChanged
    {
        public string DisplayName { get; set; }

        private string _imageuri;
        public string ImageUri
        {
            get => _imageuri;
            set
            {
                _imageuri = value;
                OnPropertyChanged(nameof(ImageUri));
            }
        }

        public TileType? Classification { get; set; }
        public ElementType? ElementType { get; set; }
        public EntityType? EntityType { get; set; }
        public TileProperty TileProperty { get; set; }

        public TileEntity()
        {
            TileProperty = new TileProperty();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
