using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OniTemplate.Model;
using Xunit;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OniTemplate.Test
{
    public class YamlTests
    {
        [Fact]
        [Trait("Category", "Integration")]
        public void DeserializeExistingFileTest()
        {
            var baseDir =
                @"F:\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\StreamingAssets\templates\poi";
            var yamlFiles = Directory.GetFiles(baseDir);
            foreach (var filePath in yamlFiles)
            {
                var reader = new StreamReader(filePath);
                var yamlString = reader.ReadToEnd();

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build();

                // assertion provided by no exception
                var strongGraph = deserializer.Deserialize<Template>(yamlString);
            }
        }
    }
}
