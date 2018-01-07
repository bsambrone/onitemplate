﻿using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace OniTemplate.Model
{
    public class Building
    {
        public string Id { get; set; }
        [YamlMember(ApplyNamingConventions = false)]
        public int location_x { get; set; }
        [YamlMember(ApplyNamingConventions = false)]
        public int location_y { get; set; }
        public string DiseaseName { get; set; }
        public int DiseaseCount { get; set; }
        public int Connections { get; set; }
        public string RotationOrientation { get; set; }
        public string Element { get; set; }
        public double Temperature { get; set; }
        public List<Storage> Storage { get; set; }
        public Rottable Rottable { get; set; }
        public List<Amount> Amounts { get; set; }
        [YamlMember(ApplyNamingConventions = false)]
        public List<OtherValue> other_values { get; set; }

    }
}
