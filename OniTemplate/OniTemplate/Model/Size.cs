using YamlDotNet.Serialization;

namespace OniTemplate.Model
{
    public class Size
    {
        [YamlMember(ApplyNamingConventions = false)]
        public int X { get; set; }

        [YamlMember(ApplyNamingConventions = false)]
        public int Y { get; set; }
    }
}
