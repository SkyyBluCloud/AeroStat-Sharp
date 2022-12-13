using System;
using System.Collections.Generic;

namespace AeroStat_Sharp
{
    public class Apron : ISurface
    {
        public long id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string sfcName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurface.Status status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurface.DimUnit dimUnit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurface.MassUnit massUnit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? length { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? pcn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? pavementType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? maxWeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? remarks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? rampPrefix { get; set; }
        public long? rows { get; set; }
        public bool latinRows { get; set; } = true;
        public List<Spot>? spots { get; set; }
        public bool latinSpots { get; set; } = false;
        public long? maxOnGround { get; set; }
    }
}
