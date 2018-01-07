using YamlDotNet.Serialization;

namespace OniTemplate.Model
{
    public class Cell
    {
        public string Element { get; set; }
        public double Mass { get; set; }
        public double Temperature { get; set; }
        [YamlMember(ApplyNamingConventions = false)]
        public int location_x { get; set; }
        [YamlMember(ApplyNamingConventions = false)]
        public int location_y { get; set; }
        public string DiseaseName { get; set; }
        public int DiseaseCount { get; set; }
        [YamlMember(ApplyNamingConventions = false)]
        public bool preventFoWReveal { get; set; }
    }
}
