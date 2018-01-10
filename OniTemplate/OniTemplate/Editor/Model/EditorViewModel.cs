using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using OniTemplate.Annotations;

namespace OniTemplate.Editor.Model
{
    public class EditorViewModel : INotifyPropertyChanged
    {
        public string TemplateName { get; set; } = "New Template";
        public ObservableCollection<TileCollection> TileCollections { get; set; }
        public GridCell[] Cells { get; set; }
        public TileEntity SelectedTileEntity { get; set; }
        public PropertyVisibility PropertyVisibility { get; set; }

        // build our palette in the default ctor. this needs to go into configuration later.
        public EditorViewModel()
        {
            PropertyVisibility = new PropertyVisibility {ShowMass = true, ShowElement = true};
            SelectedTileEntity = new TileEntity();
            SelectedTileEntity.Classification = TileType.Null;
            SelectedTileEntity.TileProperty = new TileProperty()
            {
                TemperatureKelvin = 300,
                MassKiloGrams = 1000,
                DiseaseCount = null,
                DiseaseName = null,
                HitPoints =  25,
                Maturity = 1
            };

            TileCollections = new ObservableCollection<TileCollection>();

            LoadTileCollections();

            // set an initial tile
            SetSelectedTile(TileCollections[0].Items[0]);
        }

        public void ResetCells(BorderGrid grid)
        {
            Cells = new GridCell[256];
            int iterator = 0;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    var cell = new GridCell();
                    // child 1 will be the element
                    cell.TileEntities.Add(new TileEntity
                    {
                        DisplayName = "null",
                        ImageUri = "null.png"
                    });
                    // child 2 will be any optional entities
                    cell.TileEntities.Add(new TileEntity
                    {
                        DisplayName = "null",
                        ImageUri = "null.png"
                    });
                    cell.Row = x;
                    cell.Column = y;
                    Cells[iterator] = cell;

                    var container = new StackPanel();
                    Grid.SetRow(container, x);
                    Grid.SetColumn(container, y);

                    var baseImage = new Image();
                    baseImage.DataContext = cell.TileEntities[0];
                    baseImage.Source = new BitmapImage(new Uri("pack://application:,,,/OniTemplate;component/Images/" + cell.TileEntities[0].ImageUri));

                    var entityImage = new Image();
                    entityImage.DataContext = cell.TileEntities[1];
                    entityImage.Source = new BitmapImage(new Uri("pack://application:,,,/OniTemplate;component/Images/" + cell.TileEntities[1].ImageUri));

                    container.Children.Add(baseImage);
                    container.Children.Add(entityImage);

                    grid.Children.Add(container);
                    iterator++;
                }
            }
        }

        public void SetSelectedTile(TileEntity tile)
        {
            SelectedTileEntity.Classification = tile.Classification;
            SelectedTileEntity.EntityType = tile.EntityType;
            SelectedTileEntity.ElementType = tile.ElementType;
            SelectedTileEntity.DisplayName = tile.DisplayName;
            SelectedTileEntity.ImageUri = tile.ImageUri;
            SelectedTileEntity.TileProperty = tile.TileProperty;

            // set property visibility
            PropertyVisibility.ShowDisease = false;
            PropertyVisibility.ShowElement = false;
            PropertyVisibility.ShowMass = false;
            PropertyVisibility.ShowHitpoints = false;
            PropertyVisibility.ShowMaturation = false;

            if (tile.Classification != null && (tile.Classification == TileType.SolidElement ||
                                                tile.Classification == TileType.Liquid ||
                                                tile.Classification == TileType.GasElement))
            {
                PropertyVisibility.ShowDisease = true;
                PropertyVisibility.ShowElement = true;
                PropertyVisibility.ShowMass = true;
            }

            if (tile.EntityType != null && tile.Classification == TileType.Creature)
            {
                PropertyVisibility.ShowHitpoints = true;
            }

            if (tile.EntityType != null && tile.Classification == TileType.Plant)
            {
                PropertyVisibility.ShowMaturation = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadTileCollections()
        {
            var minerals = new TileCollection();
            minerals.Name = "Raw Minerals";
            minerals.Items = new ObservableCollection<TileEntity>();
            //minerals.Items.Add(new TileEntity { DisplayName = "Abyssalite", ImageUri = "50px-Abyssalite.png", Classification = TileType.SolidElement, ElementType = ElementType.Abyssalite});
            minerals.Items.Add(new TileEntity { DisplayName = "Diamond", ImageUri = "placeholder.png", Classification = TileType.SolidElement, ElementType = ElementType.Diamond });
            minerals.Items.Add(new TileEntity { DisplayName = "Granite", ImageUri = "50px-Granite.png", Classification = TileType.SolidElement, ElementType = ElementType.Granite });
            minerals.Items.Add(new TileEntity { DisplayName = "Igneous Rock", ImageUri = "50px-Igneous_rock.png", Classification = TileType.SolidElement, ElementType = ElementType.IgneousRock });
            minerals.Items.Add(new TileEntity { DisplayName = "Obsidian", ImageUri = "50px-Obsidian.png", Classification = TileType.SolidElement, ElementType = ElementType.Obsidian });
            minerals.Items.Add(new TileEntity { DisplayName = "Sandstone", ImageUri = "50px-Sand_stone.png", Classification = TileType.SolidElement, ElementType = ElementType.Sandstone });
            minerals.Items.Add(new TileEntity { DisplayName = "Sedimentary Rock", ImageUri = "50px-Sedimentary_Rock.png", Classification = TileType.SolidElement, ElementType = ElementType.SedimentaryRock });

            var metals = new TileCollection();
            metals.Name = "Raw Metals";
            metals.Items = new ObservableCollection<TileEntity>();
            metals.Items.Add(new TileEntity { DisplayName = "Copper Ore", ImageUri = "50px-Copper_Ore.png", Classification = TileType.SolidElement, ElementType = ElementType.CopperOre });
            metals.Items.Add(new TileEntity { DisplayName = "Electrum", ImageUri = "50px-Electrum.png", Classification = TileType.SolidElement, ElementType = ElementType.Electrum });
            metals.Items.Add(new TileEntity { DisplayName = "Gold Amalgam", ImageUri = "50px-Gold_Amalgam.png", Classification = TileType.SolidElement, ElementType = ElementType.GoldAmalgam });
            metals.Items.Add(new TileEntity { DisplayName = "Iron Ore", ImageUri = "50px-Iron_Ore.png", Classification = TileType.SolidElement, ElementType = ElementType.IronOre });
            metals.Items.Add(new TileEntity { DisplayName = "Pyrite", ImageUri = "50px-Pyrite.png", Classification = TileType.SolidElement, ElementType = ElementType.Pyrite });
            metals.Items.Add(new TileEntity { DisplayName = "Wolframite", ImageUri = "50px-Wolframite.png", Classification = TileType.SolidElement, ElementType = ElementType.Wolframite });

            var agri = new TileCollection();
            agri.Name = "Agricultural";
            agri.Items = new ObservableCollection<TileEntity>();
            agri.Items.Add(new TileEntity { DisplayName = "Fertilizer", ImageUri = "50px-Fertilizer.png", Classification = TileType.SolidElement, ElementType = ElementType.Fertilizer });
            agri.Items.Add(new TileEntity { DisplayName = "Phosphorite", ImageUri = "50px-Phosphorite.png", Classification = TileType.SolidElement, ElementType = ElementType.Phosphorite });

            var soil = new TileCollection();
            soil.Name = "Cultivable Soil";
            soil.Items = new ObservableCollection<TileEntity>();
            soil.Items.Add(new TileEntity { DisplayName = "Dirt", ImageUri = "50px-Dirt.png", Classification = TileType.SolidElement, ElementType = ElementType.Dirt });
            soil.Items.Add(new TileEntity { DisplayName = "Clay", ImageUri = "50px-Clay.png", Classification = TileType.SolidElement, ElementType = ElementType.Clay });

            var organic = new TileCollection();
            organic.Name = "Organic";
            organic.Items = new ObservableCollection<TileEntity>();
            organic.Items.Add(new TileEntity { DisplayName = "Algae", ImageUri = "50px-Algae.png", Classification = TileType.SolidElement, ElementType = ElementType.Algae });
            organic.Items.Add(new TileEntity { DisplayName = "Polluted Dirt", ImageUri = "50px-Polluted_Dirt_Item.png", Classification = TileType.SolidElement, ElementType = ElementType.PollutedDirt });
            organic.Items.Add(new TileEntity { DisplayName = "Slime", ImageUri = "50px-Slime.png", Classification = TileType.SolidElement, ElementType = ElementType.Slime });

            var consumables = new TileCollection();
            consumables.Name = "Consumable Ores";
            consumables.Items = new ObservableCollection<TileEntity>();
            //consumables.Items.Add(new TileEntity { DisplayName = "Coal", ImageUri = "50px-Coal.png", Classification = TileType.SolidElement, ElementType = ElementType.Coal });
            consumables.Items.Add(new TileEntity { DisplayName = "Oxylite", ImageUri = "50px-Oxylite.png", Classification = TileType.SolidElement, ElementType = ElementType.Oxylite });
            consumables.Items.Add(new TileEntity { DisplayName = "Bleach Stone", ImageUri = "50px-Bleach_Stone.png", Classification = TileType.SolidElement, ElementType = ElementType.BleachStone });

            var filtration = new TileCollection();
            filtration.Name = "Filtration Medium";
            filtration.Items = new ObservableCollection<TileEntity>();
            filtration.Items.Add(new TileEntity { DisplayName = "Sand", ImageUri = "50px-Sand.png", Classification = TileType.SolidElement, ElementType = ElementType.Sand });

            var liquify = new TileCollection();
            liquify.Name = "Liquifiable";
            liquify.Items = new ObservableCollection<TileEntity>();
            liquify.Items.Add(new TileEntity { DisplayName = "Ice", ImageUri = "50px-Ice.png", Classification = TileType.SolidElement, ElementType = ElementType.Ice });
            liquify.Items.Add(new TileEntity { DisplayName = "Polluted Ice", ImageUri = "50px-Polluted_Ice.png", Classification = TileType.SolidElement, ElementType = ElementType.PollutedIce });
            liquify.Items.Add(new TileEntity { DisplayName = "Snow", ImageUri = "50px-Snow.png", Classification = TileType.SolidElement, ElementType = ElementType.Snow });

            var special = new TileCollection();
            special.Name = "Special";
            special.Items = new ObservableCollection<TileEntity>();
            special.Items.Add(new TileEntity { DisplayName = "Neutronium", ImageUri = "50px-Neutronium.png", Classification = TileType.SolidElement, ElementType = ElementType.Neutronium });
            //special.Items.Add(new TileEntity { DisplayName = "Plastic", ImageUri = "50px-Pure_plastic.png", Classification = TileType.SolidElement, ElementType = ElementType.Plastic });

            var liquids = new TileCollection();
            liquids.Name = "Liquids";
            liquids.Items = new ObservableCollection<TileEntity>();
            liquids.Items.Add(new TileEntity { DisplayName = "Crude Oil", ImageUri = "placeholder.png", Classification = TileType.Liquid, ElementType = ElementType.CrudeOil });
            liquids.Items.Add(new TileEntity { DisplayName = "Water", ImageUri = "50px-Water-icon.png", Classification = TileType.Liquid, ElementType = ElementType.Water });
            liquids.Items.Add(new TileEntity { DisplayName = "Polluted Water", ImageUri = "50px-Polluted_Water.png", Classification = TileType.Liquid, ElementType = ElementType.PollutedWater });
            liquids.Items.Add(new TileEntity { DisplayName = "Magma", ImageUri = "50px-Magma.png", Classification = TileType.Liquid, ElementType = ElementType.Magma });

            var breathable = new TileCollection();
            breathable.Name = "Breathable Gases";
            breathable.Items = new ObservableCollection<TileEntity>();
            breathable.Items.Add(new TileEntity { DisplayName = "Oxygen", ImageUri = "50px-Oxygen-icon.png", Classification = TileType.GasElement, ElementType = ElementType.Oxygen });
            breathable.Items.Add(new TileEntity { DisplayName = "Polluted Oxygen", ImageUri = "50px-Polluted_Oxygen.png", Classification = TileType.GasElement, ElementType = ElementType.PollutedOxygen });

            var unbreathable = new TileCollection();
            unbreathable.Name = "Unbreathable Gases";
            unbreathable.Items = new ObservableCollection<TileEntity>();
            unbreathable.Items.Add(new TileEntity { DisplayName = "Carbon Dioxide", ImageUri = "50px-Carbon_Dioxide.png", Classification = TileType.GasElement, ElementType = ElementType.CarbonDioxide });
            unbreathable.Items.Add(new TileEntity { DisplayName = "Chlorine", ImageUri = "50px-Chlorine.png", Classification = TileType.GasElement, ElementType = ElementType.Chlorine });
            unbreathable.Items.Add(new TileEntity { DisplayName = "Hydrogen", ImageUri = "50px-Hydrogen.png", Classification = TileType.GasElement, ElementType = ElementType.Hydrogen });
            //unbreathable.Items.Add(new TileEntity { DisplayName = "Mercury Gas", ImageUri = "50px-Mercury_Gas.png", Classification = TileType.GasElement, ElementType = ElementType.MercuryGas });
            unbreathable.Items.Add(new TileEntity { DisplayName = "Natural Gas", ImageUri = "placeholder.png", Classification = TileType.GasElement, ElementType = ElementType.NaturalGas });
            unbreathable.Items.Add(new TileEntity { DisplayName = "Steam", ImageUri = "placeholder.png", Classification = TileType.GasElement, ElementType = ElementType.Steam });
            unbreathable.Items.Add(new TileEntity { DisplayName = "Vacuum", ImageUri = "placeholder.png", Classification = TileType.GasElement, ElementType = ElementType.Vacuum });

            var plants = new TileCollection();
            plants.Name = "Plants";
            //plants.Items.Add(new TileEntity { DisplayName = "Blossom", EntityImageUri = "40px-Blossom_Seed_Blank.png", Classification = TileType.Plant, EntityType = EntityType.ColdBreather});
            //plants.Items.Add(new TileEntity { DisplayName = "Briar", EntityImageUri = "40px-Briar_Seed_Blank.png", Classification = TileType.Plant, EntityType = EntityType.Glom });
            //plants.Items.Add(new TileEntity { DisplayName = "Mealwood", EntityImageUri = "40px-Mealwood_Seed_Blank.png", Classification = TileType.Plant, EntityType = EntityType.BasicFabricPlant });
            plants.Items.Add(new TileEntity { DisplayName = "Balm Lily", ImageUri = "placeholder.png", Classification = TileType.Plant, EntityType = EntityType.SwampLily });
            plants.Items.Add(new TileEntity { DisplayName = "Pincha Pepper", ImageUri = "40px-Pincha_Pepper_Seed_Blank.png", Classification = TileType.Plant, EntityType = EntityType.SpiceVine });
            plants.Items.Add(new TileEntity { DisplayName = "Sleet Wheat", ImageUri = "40px-Sleet_Wheat_Grain_Blank.png", Classification = TileType.Plant, EntityType = EntityType.ColdWheat });
            plants.Items.Add(new TileEntity { DisplayName = "Thimble Reed", ImageUri = "40px-Thimble_Reed_Seed_Blank.png", Classification = TileType.Plant, EntityType = EntityType.BasicFabricPlant });
            plants.Items.Add(new TileEntity { DisplayName = "Wheezewort", ImageUri = "40px-Wheezewort_Seed_Blank.png", Classification = TileType.Plant, EntityType = EntityType.ColdBreather });


            var creatures = new TileCollection();
            creatures.Name = "Creatures";
            //creatures.Items.Add(new TileEntity { DisplayName = "Hatch", ImageUri = "100px-Hatch.png", Classification = TileType.Creature, EntityType = EntityType.Hatch});
            creatures.Items.Add(new TileEntity { DisplayName = "Puft", ImageUri = "100px-Puft.png", Classification = TileType.Creature, EntityType = EntityType.Puft});
            creatures.Items.Add(new TileEntity { DisplayName = "Lightbug", ImageUri = "placeholder.png", Classification = TileType.Creature, EntityType = EntityType.LightBug });
            creatures.Items.Add(new TileEntity { DisplayName = "Slickster", ImageUri = "100px-Slickster.png", Classification = TileType.Creature, EntityType = EntityType.Oilfloater});
            //creatures.Items.Add(new TileEntity { DisplayName = "Morb", ImageUri = "MORB.png", Classification = TileType.Creature, EntityType = EntityType.Glom});

            TileCollections.Add(minerals);
            TileCollections.Add(metals);
            TileCollections.Add(agri);
            TileCollections.Add(soil);
            TileCollections.Add(organic);
            TileCollections.Add(consumables);
            TileCollections.Add(filtration);
            TileCollections.Add(liquify);
            TileCollections.Add(special);
            TileCollections.Add(liquids);
            TileCollections.Add(breathable);
            TileCollections.Add(unbreathable);
            TileCollections.Add(plants);
            TileCollections.Add(creatures);
        }

    }
}
