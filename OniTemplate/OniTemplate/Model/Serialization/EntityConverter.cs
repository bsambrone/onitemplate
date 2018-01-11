using System;
using OniTemplate.Editor.Model;

namespace OniTemplate.Model.Serialization
{
    public static class EntityConverter
    {
        public static string Convert(EntityType entity)
        {
            if (entity == EntityType.BasicFabricPlant) return "BasicFabricPlant";
            if (entity == EntityType.ChlorineGeyser) throw new NotImplementedException("ChlorineGeyser not supported");
            if (entity == EntityType.ColdBreather) return "ColdBreather";
            if (entity == EntityType.ColdWheat) return "ColdWheat";
            if (entity == EntityType.GeneShuffler) throw new NotImplementedException("GeneShuffler not supported");
            if (entity == EntityType.Geyser) throw new NotImplementedException("Geyser not supported");
            if (entity == EntityType.Glom) throw new NotImplementedException("Glom not supported");
            if (entity == EntityType.LightBug) return "LightBug";
            if (entity == EntityType.MethaneGeyser) throw new NotImplementedException("MethaneGeyser not supported");
            if (entity == EntityType.MushroomPlant) return "MushroomPlant";
            if (entity == EntityType.Oilfloater) return "Oilfloater";
            if (entity == EntityType.OilWell) throw new NotImplementedException("OilWell not supported");
            if (entity == EntityType.PropClock) throw new NotImplementedException("PropClock not supported");
            if (entity == EntityType.PropDesk) throw new NotImplementedException("PropDesk not supported");
            if (entity == EntityType.PropLadder) throw new NotImplementedException("PropLadder not supported");
            if (entity == EntityType.PropLight) throw new NotImplementedException("PropLight not supported");
            if (entity == EntityType.PropTable) throw new NotImplementedException("PropTable not supported");
            if (entity == EntityType.Puft) return "Puft";
            if (entity == EntityType.SetLocker) throw new NotImplementedException("SetLocker not supported");
            if (entity == EntityType.SpiceVine) return "SpiceVine";
            if (entity == EntityType.SwampLily) return "SwampLily";
            if (entity == EntityType.VendingMachine) throw new NotImplementedException("VendingMachine not supported");

            throw new ArgumentException("Entity not supported");
        }

        public static EntityType Convert(string entity)
        {
            if (entity == "BasicFabricPlant") return EntityType.BasicFabricPlant;
            if (entity == "ChlorineGeyser") return EntityType.ChlorineGeyser;
            if (entity == "ColdBreather") return EntityType.ColdBreather;
            if (entity == "ColdWheat") return EntityType.ColdWheat;
            if (entity == "GeneShuffler") return EntityType.GeneShuffler;
            if (entity == "Geyser") return EntityType.Geyser;
            if (entity == "Glom") return EntityType.Glom;
            if (entity == "LightBug") return EntityType.LightBug;
            if (entity == "MethaneGeyser") return EntityType.MethaneGeyser;
            if (entity == "MushroomPlant") return EntityType.MushroomPlant;
            if (entity == "Oilfloater") return EntityType.Oilfloater;
            if (entity == "OilWell") return EntityType.OilWell;
            if (entity == "PropClock") return EntityType.PropClock;
            if (entity == "PropDesk") return EntityType.PropDesk;
            if (entity == "PropLadder") return EntityType.PropLadder;
            if (entity == "PropLight") return EntityType.PropLight;
            if (entity == "PropTable") return EntityType.PropTable;
            if (entity == "Puft") return EntityType.Puft;
            if (entity == "SetLocker") return EntityType.SetLocker;
            if (entity == "SpiceVine") return EntityType.SpiceVine;
            if (entity == "SwampLily") return EntityType.SwampLily;
            if (entity == "VendingMachine") return EntityType.VendingMachine;

            throw new ArgumentException("Entity not supported");
        }
    }
}
