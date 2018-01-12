using System;
using OniTemplate.Editor.Model;

namespace OniTemplate.Model.Serialization
{
    public static class ClassificationConverter
    {
        public static TileType Convert(ElementType tileType)
        {
            if (tileType == ElementType.Abyssalite) return TileType.SolidElement;
            if (tileType == ElementType.Diamond) return TileType.SolidElement;
            if (tileType == ElementType.Granite) return TileType.SolidElement;
            if (tileType == ElementType.IgneousRock) return TileType.SolidElement;
            if (tileType == ElementType.Obsidian) return TileType.SolidElement;
            if (tileType == ElementType.Sandstone) return TileType.SolidElement;
            if (tileType == ElementType.SedimentaryRock) return TileType.SolidElement;
            if (tileType == ElementType.CopperOre) return TileType.SolidElement;
            if (tileType == ElementType.Electrum) return TileType.SolidElement;
            if (tileType == ElementType.GoldAmalgam) return TileType.SolidElement;
            if (tileType == ElementType.IronOre) return TileType.SolidElement;
            if (tileType == ElementType.Pyrite) return TileType.SolidElement;
            if (tileType == ElementType.Wolframite) return TileType.SolidElement;
            if (tileType == ElementType.Fertilizer) return TileType.SolidElement;
            if (tileType == ElementType.Phosphorite) return TileType.SolidElement;
            if (tileType == ElementType.Dirt) return TileType.SolidElement;
            if (tileType == ElementType.Clay) return TileType.SolidElement;
            if (tileType == ElementType.Algae) return TileType.SolidElement;
            if (tileType == ElementType.PollutedDirt) return TileType.SolidElement;
            if (tileType == ElementType.Slime) return TileType.SolidElement;
            if (tileType == ElementType.Coal) return TileType.SolidElement;
            if (tileType == ElementType.Oxylite) return TileType.SolidElement;
            if (tileType == ElementType.BleachStone) return TileType.SolidElement;
            if (tileType == ElementType.Sand) return TileType.SolidElement;
            if (tileType == ElementType.Ice) return TileType.SolidElement;
            if (tileType == ElementType.PollutedIce) return TileType.SolidElement;
            if (tileType == ElementType.Snow) return TileType.SolidElement;
            if (tileType == ElementType.Neutronium) return TileType.SolidElement;
            if (tileType == ElementType.Plastic) return TileType.SolidElement;
            if (tileType == ElementType.CrudeOil) return TileType.Liquid;
            if (tileType == ElementType.Water) return TileType.Liquid;
            if (tileType == ElementType.PollutedWater) return TileType.Liquid;
            if (tileType == ElementType.Magma) return TileType.Liquid;
            if (tileType == ElementType.Oxygen) return TileType.GasElement;
            if (tileType == ElementType.PollutedOxygen) return TileType.GasElement;
            if (tileType == ElementType.CarbonDioxide) return TileType.GasElement;
            if (tileType == ElementType.Chlorine) return TileType.GasElement;
            if (tileType == ElementType.Hydrogen) return TileType.GasElement;
            if (tileType == ElementType.MercuryGas) return TileType.GasElement;
            if (tileType == ElementType.NaturalGas) return TileType.GasElement;
            if (tileType == ElementType.Steam) return TileType.GasElement;
            if (tileType == ElementType.Vacuum) return TileType.GasElement;

            throw new ArgumentException("Element not supported");
        }

        public static TileType Convert(EntityType tileType)
        {
            if (tileType == EntityType.BasicFabricPlant) return TileType.Plant;
            if (tileType == EntityType.ChlorineGeyser) return TileType.Geyser;
            if (tileType == EntityType.ColdBreather) return TileType.Plant;
            if (tileType == EntityType.ColdWheat) return TileType.Plant;
            if (tileType == EntityType.GeneShuffler) return TileType.Building;
            if (tileType == EntityType.Geyser) return TileType.Geyser;
            if (tileType == EntityType.Glom) return TileType.Creature; // maybe?
            if (tileType == EntityType.LightBug) return TileType.Creature;
            if (tileType == EntityType.MethaneGeyser) return TileType.Geyser;
            if (tileType == EntityType.MushroomPlant) return TileType.Plant;
            if (tileType == EntityType.Oilfloater) return TileType.Creature;
            if (tileType == EntityType.OilWell) return TileType.Geyser;
            if (tileType == EntityType.PropClock) return TileType.Building;
            if (tileType == EntityType.PropDesk) return TileType.Building;
            if (tileType == EntityType.PropLadder) return TileType.Building;
            if (tileType == EntityType.PropLight) return TileType.Building;
            if (tileType == EntityType.PropTable) return TileType.Building;
            if (tileType == EntityType.Puft) return TileType.Creature;
            if (tileType == EntityType.SetLocker) return TileType.Building;
            if (tileType == EntityType.SpiceVine) return TileType.Plant;
            if (tileType == EntityType.SwampLily) return TileType.Plant;
            if (tileType == EntityType.VendingMachine) return TileType.Building;

            throw new ArgumentException("Entity not supported");
        }
    }
}
