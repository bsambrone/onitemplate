﻿using System;
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

            var minerals = new PaletteCollection();
            minerals.Name = "Raw minerals";
            minerals.Items = new ObservableCollection<PaletteItem>();
            minerals.Items.Add(new PaletteItem { Name = "Abyssalite", ImageUri = "50px-Abyssalite.png" });
            minerals.Items.Add(new PaletteItem { Name = "Granite", ImageUri = "50px-Granite.png" });
            minerals.Items.Add(new PaletteItem { Name = "Igneous Rock", ImageUri = "50px-Igneous_rock.png" });
            minerals.Items.Add(new PaletteItem { Name = "Obsidian", ImageUri = "50px-Obsidian.png" });
            minerals.Items.Add(new PaletteItem { Name = "Sandstone", ImageUri = "50px-Sand_stone.png" });
            minerals.Items.Add(new PaletteItem { Name = "Sedimentary Rock", ImageUri = "50px-Sedimentary_Rock.png" });

            var metals = new PaletteCollection();
            metals.Name = "Raw Metals";
            metals.Items = new ObservableCollection<PaletteItem>();
            metals.Items.Add(new PaletteItem { Name = "Copper Ore", ImageUri = "50px-Copper_Ore.png" });
            metals.Items.Add(new PaletteItem { Name = "Electrum", ImageUri = "50px-Electrum.png" });
            metals.Items.Add(new PaletteItem { Name = "Gold Amalgam", ImageUri = "50px-Gold_Amalgam.png" });
            metals.Items.Add(new PaletteItem { Name = "Iron Ore", ImageUri = "50px-Iron_Ore.png" });
            metals.Items.Add(new PaletteItem { Name = "Pyrite", ImageUri = "50px-Pyrite.png" });
            metals.Items.Add(new PaletteItem { Name = "Wolframite", ImageUri = "50px-Wolframite.png" });

            var agri = new PaletteCollection();
            agri.Name = "Agricultural";
            agri.Items = new ObservableCollection<PaletteItem>();
            agri.Items.Add(new PaletteItem { Name = "Fertilizer", ImageUri = "50px-Fertilizer.png" });
            agri.Items.Add(new PaletteItem { Name = "Phosphorite", ImageUri = "50px-Phosphorite.png" });

            var soil = new PaletteCollection();
            soil.Name = "Cultivable Soil";
            soil.Items = new ObservableCollection<PaletteItem>();
            soil.Items.Add(new PaletteItem { Name = "Dirt", ImageUri = "50px-Dirt.png" });
            soil.Items.Add(new PaletteItem { Name = "Clay", ImageUri = "50px-Clay.png" });

            var organic = new PaletteCollection();
            organic.Name = "Organic";
            organic.Items = new ObservableCollection<PaletteItem>();
            organic.Items.Add(new PaletteItem { Name = "Algae", ImageUri = "50px-Algae.png" });
            organic.Items.Add(new PaletteItem { Name = "Polluted Dirt", ImageUri = "50px-Polluted_Dirt_Item.png" });
            organic.Items.Add(new PaletteItem { Name = "Slime", ImageUri = "50px-Slime.png" });

            var consumables = new PaletteCollection();
            consumables.Name = "Consumable Ores";
            consumables.Items = new ObservableCollection<PaletteItem>();
            consumables.Items.Add(new PaletteItem { Name = "Coal", ImageUri = "50px-Coal.png" });
            consumables.Items.Add(new PaletteItem { Name = "Oxylite", ImageUri = "50px-Oxylite.png" });
            consumables.Items.Add(new PaletteItem { Name = "Bleach Stone", ImageUri = "50px-Bleach_Stone.png" });

            var filtration = new PaletteCollection();
            filtration.Name = "Filtration Medium";
            filtration.Items = new ObservableCollection<PaletteItem>();
            filtration.Items.Add(new PaletteItem { Name = "Sand", ImageUri = "50px-Sand.png" });

            var liquify = new PaletteCollection();
            liquify.Name = "Liquifiable";
            liquify.Items = new ObservableCollection<PaletteItem>();
            liquify.Items.Add(new PaletteItem { Name = "Ice", ImageUri = "50px-Ice.png" });
            liquify.Items.Add(new PaletteItem { Name = "Polluted Ice", ImageUri = "50px-Polluted_Ice.png" });
            liquify.Items.Add(new PaletteItem { Name = "Snow", ImageUri = "50px-Snow.png" });

            var special = new PaletteCollection();
            special.Name = "Special";
            special.Items = new ObservableCollection<PaletteItem>();
            special.Items.Add(new PaletteItem { Name = "Neutronium", ImageUri = "50px-Neutronium.png" });
            special.Items.Add(new PaletteItem { Name = "Plastic", ImageUri = "50px-Pure_plastic.png" });

            var liquids = new PaletteCollection();
            liquids.Name = "Liquids";
            liquids.Items = new ObservableCollection<PaletteItem>();
            liquids.Items.Add(new PaletteItem { Name = "Water", ImageUri = "50px-Water-icon.png" });
            liquids.Items.Add(new PaletteItem { Name = "Polluted Water", ImageUri = "50px-Polluted_Water.png" });
            liquids.Items.Add(new PaletteItem { Name = "Magma", ImageUri = "50px-Magma.png" });

            var breathable = new PaletteCollection();
            breathable.Name = "Breathable Gases";
            breathable.Items = new ObservableCollection<PaletteItem>();
            breathable.Items.Add(new PaletteItem { Name = "Oxygen", ImageUri = "50px-Oxygen-icon.png" });
            breathable.Items.Add(new PaletteItem { Name = "Polluted Oxygen", ImageUri = "50px-Polluted_Oxygen.png" });

            var unbreathable = new PaletteCollection();
            unbreathable.Name = "Unbreathable Gases";
            unbreathable.Items = new ObservableCollection<PaletteItem>();
            unbreathable.Items.Add(new PaletteItem { Name = "Carbon Dioxide", ImageUri = "50px-Carbon_Dioxide.png" });
            unbreathable.Items.Add(new PaletteItem { Name = "Chlorine", ImageUri = "50px-Chlorine.png" });
            unbreathable.Items.Add(new PaletteItem { Name = "Hydrogen", ImageUri = "50px-Hydrogen.png" });
            unbreathable.Items.Add(new PaletteItem { Name = "Mercury Gas", ImageUri = "50px-Mercury_Gas.png" });
            unbreathable.Items.Add(new PaletteItem { Name = "Natural Gas", ImageUri = "placeholder.png" });
            unbreathable.Items.Add(new PaletteItem { Name = "Steam", ImageUri = "placeholder.png" });
            unbreathable.Items.Add(new PaletteItem { Name = "Vacuum", ImageUri = "placeholder.png" });


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
