using System;
using OniTemplate.Editor.Model;

namespace OniTemplate.Helpers
{
    public static class ImageLocator
    {
        public static string Locate(ElementType elementType)
        {
            if (elementType == ElementType.Abyssalite) return "50px-Abyssalite.png";
            if (elementType == ElementType.Diamond) return "placeholder.png";
            if (elementType == ElementType.Granite) return "50px-Granite.png";
            if (elementType == ElementType.IgneousRock) return "50px-Igneous_rock.png";
            if (elementType == ElementType.Obsidian) return "50px-Obsidian.png";
            if (elementType == ElementType.Sandstone) return "50px-Sand_stone.png";
            if (elementType == ElementType.SedimentaryRock) return "50px-Sedimentary_Rock.png";
            if (elementType == ElementType.CopperOre) return "50px-Copper_Ore.png";
            if (elementType == ElementType.Electrum) return "50px-Electrum.png";
            if (elementType == ElementType.GoldAmalgam) return "50px-Gold_Amalgam.png";
            if (elementType == ElementType.IronOre) return "50px-Iron_Ore.png";
            if (elementType == ElementType.Pyrite) return "50px-Pyrite.png";
            if (elementType == ElementType.Wolframite) return "50px-Wolframite.png";
            if (elementType == ElementType.Fertilizer) return "50px-Fertilizer.png";
            if (elementType == ElementType.Phosphorite) return "50px-Phosphorite.png";
            if (elementType == ElementType.Dirt) return "50px-Dirt.png";
            if (elementType == ElementType.Clay) return "50px-Clay.png";
            if (elementType == ElementType.Algae) return "50px-Algae.png";
            if (elementType == ElementType.PollutedDirt) return "50px-Polluted_Dirt_Item.png";
            if (elementType == ElementType.Slime) return "50px-Slime.png";
            if (elementType == ElementType.Coal) return "50px-Coal.png";
            if (elementType == ElementType.Oxylite) return "50px-Oxylite.png";
            if (elementType == ElementType.BleachStone) return "50px-Bleach_Stone.png";
            if (elementType == ElementType.Sand) return "50px-Sand.png";
            if (elementType == ElementType.Ice) return "50px-Ice.png";
            if (elementType == ElementType.PollutedIce) return "50px-Polluted_Ice.png";
            if (elementType == ElementType.Snow) return "50px-Snow.png";
            if (elementType == ElementType.Neutronium) return "50px-Neutronium.png";
            if (elementType == ElementType.Plastic) return "50px-Pure_plastic.png";
            if (elementType == ElementType.CrudeOil) return "placeholder.png";
            if (elementType == ElementType.Water) return "50px-Water-icon.png";
            if (elementType == ElementType.PollutedWater) return "50px-Polluted_Water.png";
            if (elementType == ElementType.Magma) return "50px-Magma.png";
            if (elementType == ElementType.Oxygen) return "50px-Oxygen-icon.png";
            if (elementType == ElementType.PollutedOxygen) return "50px-Polluted_Oxygen.png";
            if (elementType == ElementType.CarbonDioxide) return "50px-Carbon_Dioxide.png";
            if (elementType == ElementType.Chlorine) return "50px-Chlorine.png";
            if (elementType == ElementType.Hydrogen) return "50px-Hydrogen.png";
            if (elementType == ElementType.MercuryGas) return "50px-Mercury_Gas.png";
            if (elementType == ElementType.NaturalGas) return "placeholder.png";
            if (elementType == ElementType.Steam) return "placeholder.png";
            if (elementType == ElementType.Vacuum) return "placeholder.png";

            throw new ArgumentException("Element not supported");
        }

        public static string Locate(EntityType entityType)
        {
            if (entityType == EntityType.BasicFabricPlant) return "40px-Thimble_Reed_Seed_Blank.png";
            if (entityType == EntityType.ChlorineGeyser) return "";
            if (entityType == EntityType.ColdBreather) return "40px-Wheezewort_Seed_Blank.png";
            if (entityType == EntityType.ColdWheat) return "40px-Sleet_Wheat_Grain_Blank.png";
            if (entityType == EntityType.GeneShuffler) return "";
            if (entityType == EntityType.Geyser) return "placeholder.png";
            if (entityType == EntityType.Glom) return "placeholder.png";
            //if (entityType == EntityType.Hatch) return "100px-Hatch.png";
            if (entityType == EntityType.LightBug) return "placeholder.png";
            if (entityType == EntityType.MethaneGeyser) return "placeholder.png";
            if (entityType == EntityType.MushroomPlant) return "placeholder.png";
            if (entityType == EntityType.Oilfloater) return "100px-Slickster.png";
            if (entityType == EntityType.OilWell) return "placeholder.png";
            if (entityType == EntityType.PropClock) return "placeholder.png";
            if (entityType == EntityType.PropDesk) return "placeholder.png";
            if (entityType == EntityType.PropLadder) return "placeholder.png";
            if (entityType == EntityType.PropLight) return "placeholder.png";
            if (entityType == EntityType.PropTable) return "placeholder.png";
            if (entityType == EntityType.Puft) return "100px-Puft.png";
            if (entityType == EntityType.SetLocker) return "placeholder.png";
            if (entityType == EntityType.SpiceVine) return "40px-Pincha_Pepper_Seed_Blank.png";
            if (entityType == EntityType.SwampLily) return "placeholder.png";
            if (entityType == EntityType.VendingMachine) return "placeholder.png";

            throw new ArgumentException("Entity not supported");
        }
    }
}
