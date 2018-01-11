using OniTemplate.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OniTemplate.Extensions
{
    public class TemplateDeserializer
    {
        public Template Deserialize(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var template = deserializer.Deserialize<Template>(yaml);
            return template;
        }
    }
}
