using System.Collections.ObjectModel;

namespace OniTemplate.Editor.Model
{
    public class PaletteCollection
    {
        public string Name { get; set; }
        public ObservableCollection<PaletteItem> Items { get; set; }

        public PaletteCollection()
        {
            Items = new ObservableCollection<PaletteItem>();
        }
    }
}
