using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace OniTemplate.Editor.Model
{
    public class EditorViewModel
    {
        public ObservableCollection<ElementCollection> PaletteCollections { get; set; }
        public TemplateCell[] Cells { get; set; }
        public string TemplateName { get; set; }
        public TileProperty SelectedTileProperty { get; set; }

        // build our palette in the default ctor. this needs to go into configuration later.
        public EditorViewModel()
        {
            SelectedTileProperty = TileProperty.NullTileProperty();
            PaletteCollections = new ObservableCollection<ElementCollection>();

            var minerals = new ElementCollection();
            minerals.Name = "Raw Minerals";
            minerals.Items = new ObservableCollection<TileElement>();
            minerals.Items.Add(new TileElement { Name = "Abyssalite", ImageUri = "50px-Abyssalite.png", TileType = TileType.SolidElement});
            minerals.Items.Add(new TileElement { Name = "Diamond", ImageUri = "placeholder.png", TileType = TileType.SolidElement });
            minerals.Items.Add(new TileElement { Name = "Granite", ImageUri = "50px-Granite.png", TileType = TileType.SolidElement });
            minerals.Items.Add(new TileElement { Name = "Igneous Rock", ImageUri = "50px-Igneous_rock.png", TileType = TileType.SolidElement });
            minerals.Items.Add(new TileElement { Name = "Obsidian", ImageUri = "50px-Obsidian.png", TileType = TileType.SolidElement });
            minerals.Items.Add(new TileElement { Name = "Sandstone", ImageUri = "50px-Sand_stone.png", TileType = TileType.SolidElement });
            minerals.Items.Add(new TileElement { Name = "Sedimentary Rock", ImageUri = "50px-Sedimentary_Rock.png", TileType = TileType.SolidElement });

            var metals = new ElementCollection();
            metals.Name = "Raw Metals";
            metals.Items = new ObservableCollection<TileElement>();
            metals.Items.Add(new TileElement { Name = "Copper Ore", ImageUri = "50px-Copper_Ore.png", TileType = TileType.SolidElement });
            metals.Items.Add(new TileElement { Name = "Electrum", ImageUri = "50px-Electrum.png", TileType = TileType.SolidElement });
            metals.Items.Add(new TileElement { Name = "Gold Amalgam", ImageUri = "50px-Gold_Amalgam.png", TileType = TileType.SolidElement });
            metals.Items.Add(new TileElement { Name = "Iron Ore", ImageUri = "50px-Iron_Ore.png", TileType = TileType.SolidElement });
            metals.Items.Add(new TileElement { Name = "Pyrite", ImageUri = "50px-Pyrite.png", TileType = TileType.SolidElement });
            metals.Items.Add(new TileElement { Name = "Wolframite", ImageUri = "50px-Wolframite.png", TileType = TileType.SolidElement });

            var agri = new ElementCollection();
            agri.Name = "Agricultural";
            agri.Items = new ObservableCollection<TileElement>();
            agri.Items.Add(new TileElement { Name = "Fertilizer", ImageUri = "50px-Fertilizer.png", TileType = TileType.SolidElement });
            agri.Items.Add(new TileElement { Name = "Phosphorite", ImageUri = "50px-Phosphorite.png", TileType = TileType.SolidElement });

            var soil = new ElementCollection();
            soil.Name = "Cultivable Soil";
            soil.Items = new ObservableCollection<TileElement>();
            soil.Items.Add(new TileElement { Name = "Dirt", ImageUri = "50px-Dirt.png", TileType = TileType.SolidElement });
            soil.Items.Add(new TileElement { Name = "Clay", ImageUri = "50px-Clay.png", TileType = TileType.SolidElement });

            var organic = new ElementCollection();
            organic.Name = "Organic";
            organic.Items = new ObservableCollection<TileElement>();
            organic.Items.Add(new TileElement { Name = "Algae", ImageUri = "50px-Algae.png", TileType = TileType.SolidElement });
            organic.Items.Add(new TileElement { Name = "Polluted Dirt", ImageUri = "50px-Polluted_Dirt_Item.png", TileType = TileType.SolidElement });
            organic.Items.Add(new TileElement { Name = "Slime", ImageUri = "50px-Slime.png", TileType = TileType.SolidElement });

            var consumables = new ElementCollection();
            consumables.Name = "Consumable Ores";
            consumables.Items = new ObservableCollection<TileElement>();
            consumables.Items.Add(new TileElement { Name = "Coal", ImageUri = "50px-Coal.png", TileType = TileType.SolidElement });
            consumables.Items.Add(new TileElement { Name = "Oxylite", ImageUri = "50px-Oxylite.png", TileType = TileType.SolidElement });
            consumables.Items.Add(new TileElement { Name = "Bleach Stone", ImageUri = "50px-Bleach_Stone.png", TileType = TileType.SolidElement });

            var filtration = new ElementCollection();
            filtration.Name = "Filtration Medium";
            filtration.Items = new ObservableCollection<TileElement>();
            filtration.Items.Add(new TileElement { Name = "Sand", ImageUri = "50px-Sand.png", TileType = TileType.SolidElement });

            var liquify = new ElementCollection();
            liquify.Name = "Liquifiable";
            liquify.Items = new ObservableCollection<TileElement>();
            liquify.Items.Add(new TileElement { Name = "Ice", ImageUri = "50px-Ice.png", TileType = TileType.SolidElement });
            liquify.Items.Add(new TileElement { Name = "Polluted Ice", ImageUri = "50px-Polluted_Ice.png", TileType = TileType.SolidElement });
            liquify.Items.Add(new TileElement { Name = "Snow", ImageUri = "50px-Snow.png", TileType = TileType.SolidElement });

            var special = new ElementCollection();
            special.Name = "Special";
            special.Items = new ObservableCollection<TileElement>();
            special.Items.Add(new TileElement { Name = "Neutronium", ImageUri = "50px-Neutronium.png", TileType = TileType.SolidElement });
            special.Items.Add(new TileElement { Name = "Plastic", ImageUri = "50px-Pure_plastic.png", TileType = TileType.SolidElement });

            var liquids = new ElementCollection();
            liquids.Name = "Liquids";
            liquids.Items = new ObservableCollection<TileElement>();
            liquids.Items.Add(new TileElement { Name = "Crude Oil", ImageUri = "placeholder.png", TileType = TileType.Liquid });
            liquids.Items.Add(new TileElement { Name = "Water", ImageUri = "50px-Water-icon.png", TileType = TileType.Liquid });
            liquids.Items.Add(new TileElement { Name = "Polluted Water", ImageUri = "50px-Polluted_Water.png", TileType = TileType.Liquid });
            liquids.Items.Add(new TileElement { Name = "Magma", ImageUri = "50px-Magma.png", TileType = TileType.Liquid });

            var breathable = new ElementCollection();
            breathable.Name = "Breathable Gases";
            breathable.Items = new ObservableCollection<TileElement>();
            breathable.Items.Add(new TileElement { Name = "Oxygen", ImageUri = "50px-Oxygen-icon.png", TileType = TileType.GasElement });
            breathable.Items.Add(new TileElement { Name = "Polluted Oxygen", ImageUri = "50px-Polluted_Oxygen.png", TileType = TileType.GasElement });

            var unbreathable = new ElementCollection();
            unbreathable.Name = "Unbreathable Gases";
            unbreathable.Items = new ObservableCollection<TileElement>();
            unbreathable.Items.Add(new TileElement { Name = "Carbon Dioxide", ImageUri = "50px-Carbon_Dioxide.png", TileType = TileType.GasElement });
            unbreathable.Items.Add(new TileElement { Name = "Chlorine", ImageUri = "50px-Chlorine.png", TileType = TileType.GasElement });
            unbreathable.Items.Add(new TileElement { Name = "Hydrogen", ImageUri = "50px-Hydrogen.png", TileType = TileType.GasElement });
            unbreathable.Items.Add(new TileElement { Name = "Mercury Gas", ImageUri = "50px-Mercury_Gas.png", TileType = TileType.GasElement });
            unbreathable.Items.Add(new TileElement { Name = "Natural Gas", ImageUri = "placeholder.png", TileType = TileType.GasElement });
            unbreathable.Items.Add(new TileElement { Name = "Steam", ImageUri = "placeholder.png", TileType = TileType.GasElement });
            unbreathable.Items.Add(new TileElement { Name = "Vacuum", ImageUri = "placeholder.png", TileType = TileType.GasElement });


            PaletteCollections.Add(minerals);
            PaletteCollections.Add(metals);
            PaletteCollections.Add(agri);
            PaletteCollections.Add(soil);
            PaletteCollections.Add(organic);
            PaletteCollections.Add(consumables);
            PaletteCollections.Add(filtration);
            PaletteCollections.Add(liquify);
            PaletteCollections.Add(special);
            PaletteCollections.Add(liquids);
            PaletteCollections.Add(breathable);
            PaletteCollections.Add(unbreathable);            
        }

        public void ResetCells(BorderGrid grid)
        {
            Cells = new TemplateCell[256];
            int iterator = 0;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    var cell = new TemplateCell();
                    cell.TileElement = TileElement.NullItem();
                    cell.Row = x;
                    cell.Column = y;
                    Cells[iterator] = cell;

                    var image = new Image();
                    image.DataContext = cell;
                    Grid.SetRow(image, x);
                    Grid.SetColumn(image, y);

                    Binding imageBinding = new Binding("TileElement.ImageUri");
                    imageBinding.Source = cell;                    
                    imageBinding.Mode = BindingMode.TwoWay;
                    imageBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    imageBinding.Converter = new ImagePathConverter();
                    BindingOperations.SetBinding(image, Image.SourceProperty, imageBinding);
                    
                    grid.Children.Add(image);
                    iterator++;
                }
            }
        }

    }
}
