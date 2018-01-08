using System.Collections.Generic;

namespace OniTemplate.Model
{
    public class Template
    {
        public string Name { get; set; }
        public Info Info { get; set; }
        public List<Cell> Cells { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Pickupable> Pickupables { get; set; }
        public List<ElementalOre> ElementalOres { get; set; }
        public List<OtherEntity> OtherEntities { get; set; }

        public Template()
        {
            Info = new Info();
            Cells = new List<Cell>();
            Buildings = new List<Building>();
            Pickupables = new List<Pickupable>();
            ElementalOres = new List<ElementalOre>();
            OtherEntities = new List<OtherEntity>();
        }
    }
}
