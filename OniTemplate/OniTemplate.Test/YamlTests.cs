using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OniTemplate.Model;
using Xunit;
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
            var distinctElements = new List<string>();
            var distinctOEids = new List<string>();

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

                foreach (var item in strongGraph.Cells)
                {
                    if (!distinctElements.Contains(item.Element))
                    {
                        distinctElements.Add(item.Element);
                    }
                }
                foreach (var item in strongGraph.Buildings)
                {
                    if (!distinctElements.Contains(item.Element))
                    {
                        distinctElements.Add(item.Element);
                    }
                }
                foreach (var item in strongGraph.ElementalOres)
                {
                    if (!distinctElements.Contains(item.Element))
                    {
                        distinctElements.Add(item.Element);
                    }
                }
                foreach (var item in strongGraph.OtherEntities)
                {
                    if (!distinctElements.Contains(item.Element))
                    {
                        distinctElements.Add(item.Element);
                    }
                    if (!distinctOEids.Contains(item.Id))
                    {
                        distinctOEids.Add(item.Id);
                    }
                }
            }

            var builder = new StringBuilder();
            foreach (var element in distinctElements.OrderBy(x=>x))
            {
                builder.AppendLine(element);
            }
            File.WriteAllText(@"c:\temp\elements.txt",builder.ToString());
            builder = new StringBuilder();
            foreach (var element in distinctOEids.OrderBy(x => x))
            {
                builder.AppendLine(element);
            }
            File.WriteAllText(@"c:\temp\otherentities.txt", builder.ToString());
        }
    }
}
