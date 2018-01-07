using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
