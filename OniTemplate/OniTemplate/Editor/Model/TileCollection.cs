using System.Collections.ObjectModel;

namespace OniTemplate.Editor.Model
{
    public class TileCollection
    {
        public string Name { get; set; }
        public ObservableCollection<TileEntity> Items { get; set; }

        public TileCollection()
        {
            Items = new ObservableCollection<TileEntity>();
        }
    }
}
