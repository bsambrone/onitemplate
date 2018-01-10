using System.Collections.Generic;

namespace OniTemplate.Editor.Model
{
    public class GridCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public List<TileEntity> TileEntities { get; set; }

        public GridCell()
        {
            TileEntities = new List<TileEntity>();
        }
    }
}
