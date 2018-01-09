using System;

namespace OniTemplate.Model.Serialization
{
    public static class ElementConverter
    {
        public static string Convert(string element)
        {
            if (element == "Abyssalite") throw new NotImplementedException("Abyssalite not supported");
            if (element == "Diamond") return "Diamond";
            if (element == "Granite") return "Granite";
            if (element == "Igneous Rock") return "IgneousRock";
            if (element == "Obsidian") return "Obsidian";
            if (element == "Sandstone") return "SandStone";
            if (element == "Sedimentary Rock") return "SedimentaryRock";
            if (element == "Copper Ore") return "Cuprite";
            if (element == "Electrum") return "Electrum";
            if (element == "Gold Amalgam") return "GoldAmalgam";
            if (element == "Iron Ore") return "IronOre";
            if (element == "Pyrite") return "FoolsGold";
            if (element == "Wolframite") return "Wolframite";
            if (element == "Fertilizer") return "";
            if (element == "Phosphorite") return "Phosphorite";
            if (element == "Dirt") return "Dirt";
            if (element == "Clay") return "Clay";
            if (element == "Algae") return "Algae";
            if (element == "Polluted Dirt") return "";
            if (element == "Slime") return "SlimeMold";
            if (element == "Coal") throw new NotImplementedException("Coal not supported");
            if (element == "Oxylite") return "OxyRock";
            if (element == "Bleach Stone") return "BleachStone";
            if (element == "Sand") return "Sand";
            if (element == "Ice") return "Ice";
            if (element == "Polluted Ice") return "DirtyIce";
            if (element == "Snow") return "Snow";
            if (element == "Neutronium") return "Unobtanium";
            if (element == "Plastic") throw new NotImplementedException("Plastic not supported");
            if (element == "Crude Oil") return "CrudeOil";
            if (element == "Water") return "Water";
            if (element == "Polluted Water") return "DirtyWater";
            if (element == "Magma") return "Magma";
            if (element == "Oxygen") return "Oxygen";
            if (element == "Polluted Oxygen") return "ContaminatedOxygen";
            if (element == "Carbon Dioxide") return "CarbonDioxide";
            if (element == "Chlorine") return "ChlorineGas";
            if (element == "Hydrogen") return "Hydrogen";
            if (element == "Mercury Gas") throw new NotImplementedException("Mercury Gas not supported");
            if (element == "Natural Gas") return "Methane";
            if (element == "Steam") return "Steam";
            if (element == "Vacuum") return "Vacuum";

            throw new ArgumentException("Element not supported");
        }
    }
}
