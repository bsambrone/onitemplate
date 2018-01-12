using System.Collections.ObjectModel;

namespace OniTemplate.Editor.Model
{
    public class GridCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public ObservableCollection<TileEntity> TileEntities { get; set; }

        public GridCell()
        {
            TileEntities = new ObservableCollection<TileEntity>();
        }
    }
}
