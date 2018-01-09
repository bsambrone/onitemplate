namespace OniTemplate.Editor.Model
{
    public class TileElement
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public TileType TileType { get; set; }

        public static TileElement NullItem()
        {
            var nullPalette = new TileElement();
            nullPalette.Name = "null";
            nullPalette.ImageUri = "null.png";
            nullPalette.TileType = TileType.Null;
            return nullPalette;
        }
    }
}
