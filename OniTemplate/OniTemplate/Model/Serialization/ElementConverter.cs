using System;
using OniTemplate.Editor.Model;

namespace OniTemplate.Model.Serialization
{
    public static class ElementConverter
    {
        public static string Convert(ElementType element)
        {
            if (element == ElementType.Abyssalite) return "Katairite";
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
            if (element == ElementType.Fertilizer) return "Fertilizer";
            if (element == ElementType.Phosphorite) return "Phosphorite";
            if (element == ElementType.Dirt) return "Dirt";
            if (element == ElementType.Clay) return "Clay";
            if (element == ElementType.Algae) return "Algae";
            if (element == ElementType.PollutedDirt) return "";
            if (element == ElementType.Slime) return "SlimeMold";
            if (element == ElementType.Coal) return "Carbon";
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

        public static ElementType Convert(string element)
        {
            if (element == "Katairite") return ElementType.Abyssalite;
            if (element == "Diamond") return ElementType.Diamond;
            if (element == "Granite") return ElementType.Granite;
            if (element == "IgneousRock") return ElementType.IgneousRock;
            if (element == "Obsidian") return ElementType.Obsidian;
            if (element == "Sandstone") return ElementType.Sandstone;
            if (element == "SedimentaryRock") return ElementType.SedimentaryRock;
            if (element == "Cuprite") return ElementType.CopperOre;
            if (element == "Electrum") return ElementType.Electrum;
            if (element == "GoldAmalgam") return ElementType.GoldAmalgam;
            if (element == "IronOre") return ElementType.IronOre;
            if (element == "FoolsGold") return ElementType.Pyrite;
            if (element == "Wolframite") return ElementType.Wolframite;
            if (element == "Fertilizer") return ElementType.Fertilizer;
            if (element == "Phosphorite") return ElementType.Phosphorite;
            if (element == "Dirt") return ElementType.Dirt;
            if (element == "Clay") return ElementType.Clay;
            if (element == "Algae") return ElementType.Algae;
            if (element == "PollutedDirt") return ElementType.PollutedDirt;
            if (element == "Slime") return ElementType.Slime;
            if (element == "Carbon") return ElementType.Coal;
            if (element == "OxyRock") return ElementType.Oxylite;
            if (element == "BleachStone") return ElementType.BleachStone;
            if (element == "Sand") return ElementType.Sand;
            if (element == "Ice") return ElementType.Ice;
            if (element == "DirtyIce") return ElementType.PollutedIce;
            if (element == "Snow") return ElementType.Snow;
            if (element == "Unobtanium") return ElementType.Neutronium;
            //if (element == "Plastic") throw new NotImplementedException("Plastic not supported");
            if (element == "CrudeOil") return ElementType.CrudeOil;
            if (element == "Water") return ElementType.Water;
            if (element == "DirtyWater") return ElementType.PollutedWater;
            if (element == "Magma") return ElementType.Magma;
            if (element == "Oxygen") return ElementType.Oxygen;
            if (element == "ContaminatedOxygen") return ElementType.PollutedOxygen;
            if (element == "CarbonDioxide") return ElementType.CarbonDioxide;
            if (element == "ChlorineGas") return ElementType.Chlorine;
            if (element == "Hydrogen") return ElementType.Hydrogen;
            //if (element == "MercuryGas") throw new NotImplementedException("Mercury Gas not supported");
            if (element == "Methane") return ElementType.NaturalGas;
            if (element == "Steam") return ElementType.Steam;
            if (element == "Vacuum") return ElementType.Vacuum;

            throw new ArgumentException("Element not supported");
        }
    }
}
