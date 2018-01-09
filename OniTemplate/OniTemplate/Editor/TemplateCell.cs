using OniTemplate.Editor.Model;

namespace OniTemplate.Editor
{
    public class TemplateCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public TileElement TileElement { get; set; }
        public TileProperty TileProperty { get; set; }

        public TemplateCell()
        {
            TileElement = TileElement.NullItem();
            TileProperty = new TileProperty();
        }
    }
}
