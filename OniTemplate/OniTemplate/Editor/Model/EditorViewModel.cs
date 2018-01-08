using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OniTemplate.Editor.Model
{
    public class EditorViewModel
    {
        public ObservableCollection<PaletteCollection> PaletteCollections { get; set; }
        public TemplateCell[] Cells { get; set; }

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

        public void ResetCells(BorderGrid grid)
        {
            Cells = new TemplateCell[64];
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    var cell = new TemplateCell();
                    cell.PaletteItem = PaletteItem.NullItem();
                    cell.Row = x;
                    cell.Column = y;
                    Cells[x + y] = cell;

                    var image = new Image();
                    image.DataContext = cell;
                    Grid.SetRow(image, x);
                    Grid.SetColumn(image, y);

                    Binding imageBinding = new Binding("PaletteItem.ImageUri");
                    imageBinding.Source = cell;
                    imageBinding.Mode = BindingMode.TwoWay;
                    imageBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    imageBinding.Converter = new ImagePathConverter();
                    BindingOperations.SetBinding(image, Image.SourceProperty, imageBinding);
                    
                    grid.Children.Add(image);
                }
            }
        }

    }
}
