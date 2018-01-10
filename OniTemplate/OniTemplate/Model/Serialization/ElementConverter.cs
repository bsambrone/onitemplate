using System;
using OniTemplate.Editor.Model;

namespace OniTemplate.Model.Serialization
{
    public static class ElementConverter
    {
        public static string Convert(ElementType element)
        {
            if (element == ElementType.Abyssalite) throw new NotImplementedException("Abyssalite not supported");
            if (element == ElementType.Diamond) return "Diamond";
            if (element == ElementType.Granite) return "Granite";
            if (element == ElementType.IgneousRock) return "IgneousRock";
            if (element == ElementType.Obsidian) return "Obsidian";
            if (element == ElementType.Sandstone) return "SandStone";
            if (element == ElementType.SedimentaryRock) return "SedimentaryRock";
            if (element == ElementType.CopperOre) return "Cuprite";
            if (element == ElementType.Electrum) return "Electrum";
            if (element == ElementType.GoldAmalgam) return "GoldAmalgam";
            if (element == ElementType.IronOre) return "IronOre";
            if (element == ElementType.Pyrite) return "FoolsGold";
            if (element == ElementType.Wolframite) return "Wolframite";
            if (element == ElementType.Fertilizer) return "";
            if (element == ElementType.Phosphorite) return "Phosphorite";
            if (element == ElementType.Dirt) return "Dirt";
            if (element == ElementType.Clay) return "Clay";
            if (element == ElementType.Algae) return "Algae";
            if (element == ElementType.PollutedDirt) return "";
            if (element == ElementType.Slime) return "SlimeMold";
            if (element == ElementType.Coal) throw new NotImplementedException("Coal not supported");
            if (element == ElementType.Oxylite) return "OxyRock";
            if (element == ElementType.BleachStone) return "BleachStone";
            if (element == ElementType.Sand) return "Sand";
            if (element == ElementType.Ice) return "Ice";
            if (element == ElementType.PollutedIce) return "DirtyIce";
            if (element == ElementType.Snow) return "Snow";
            if (element == ElementType.Neutronium) return "Unobtanium";
            if (element == ElementType.Plastic) throw new NotImplementedException("Plastic not supported");
            if (element == ElementType.CrudeOil) return "CrudeOil";
            if (element == ElementType.Water) return "Water";
            if (element == ElementType.PollutedWater) return "DirtyWater";
            if (element == ElementType.Magma) return "Magma";
            if (element == ElementType.Oxygen) return "Oxygen";
            if (element == ElementType.PollutedOxygen) return "ContaminatedOxygen";
            if (element == ElementType.CarbonDioxide) return "CarbonDioxide";
            if (element == ElementType.Chlorine) return "ChlorineGas";
            if (element == ElementType.Hydrogen) return "Hydrogen";
            if (element == ElementType.MercuryGas) throw new NotImplementedException("Mercury Gas not supported");
            if (element == ElementType.NaturalGas) return "Methane";
            if (element == ElementType.Steam) return "Steam";
            if (element == ElementType.Vacuum) return "Vacuum";

            throw new ArgumentException("Element not supported");
        }
    }
}
