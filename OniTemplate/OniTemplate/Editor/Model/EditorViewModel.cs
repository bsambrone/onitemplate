using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OniTemplate.Editor.Model
{
    public class EditorViewModel
    {
        public ObservableCollection<PaletteCollection> PaletteCollections { get; set; }

        // build our palette in the default ctor. this needs to go into configuration later.
        public EditorViewModel()
        {
            PaletteCollections = new ObservableCollection<PaletteCollection>();
            var metals = new PaletteCollection();
            metals.Name = "Raw Metals";
            metals.Items = new ObservableCollection<PaletteItem>();
            metals.Items.Add(new PaletteItem { Name = "Copper Ore", ImageUri = "50px-Copper_Ore.png" });
            metals.Items.Add(new PaletteItem { Name = "Iron Ore", ImageUri = "50px-Iron_Ore.png" });
            PaletteCollections.Add(metals);
        }
    }
}
