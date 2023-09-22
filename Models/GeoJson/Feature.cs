﻿using EgretApi.Types;

namespace EgretApi.Models.GeoJson
{
    public class Feature<T> where T : new()
    {
        public Feature() {}
        public FeatureType Type { get; set; }
        public Geometry<T> Geometry { get; set; } = new Geometry<T>();
    }
}