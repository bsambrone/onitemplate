namespace OniTemplate.Model
{
    public class Info
    {
        public Size Size { get; set; }

        private int _area;
        public int Area
        {
            get => Size.X * Size.Y;
            // support direct setting only for deserialization purposes
            set => _area = value; 
        }

        public Info()
        {
            Size = new Size();
        }
    }
}
