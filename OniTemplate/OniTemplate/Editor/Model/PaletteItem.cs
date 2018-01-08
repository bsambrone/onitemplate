namespace OniTemplate.Editor.Model
{
    public class PaletteItem
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public TileType TileType { get; set; }

        public static PaletteItem NullItem()
        {
            var nullPalette = new PaletteItem();
            nullPalette.Name = "null";
            nullPalette.ImageUri = "null.png";
            nullPalette.TileType = TileType.Null;
            return nullPalette;
        }
    }
}
