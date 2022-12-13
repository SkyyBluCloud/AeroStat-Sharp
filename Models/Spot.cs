using System;

namespace AeroStat_Sharp
{
    public class Spot : ISurface
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
        public bool occupied { get; set; } = false;
    }
}
