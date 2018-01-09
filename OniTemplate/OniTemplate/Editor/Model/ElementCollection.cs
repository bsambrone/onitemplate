using System.Collections.ObjectModel;

namespace OniTemplate.Editor.Model
{
    public class ElementCollection
    {
        public string Name { get; set; }
        public ObservableCollection<TileElement> Items { get; set; }

        public ElementCollection()
        {
            Items = new ObservableCollection<TileElement>();
        }
    }
}
