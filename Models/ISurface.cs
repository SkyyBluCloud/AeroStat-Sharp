namespace AeroStat_Sharp
{
    public interface ISurface
    {
        public enum Status
        {
            OPS_NORM,
            OPS_SUSP,
            DEG,
            LTD,
            CLSD
        }
        public enum DimUnit
        {
            IN,
            FT,
            M,
            CM,
            KM
        }
        public enum MassUnit
        {
            LBS,
            KIPS,
            TONS,
            KG
        }
        public long id { get; set; }
        public string sfcName { get; set; }
        public Status status { get; set; }
        public DimUnit dimUnit { get; set; }
        public MassUnit massUnit { get; set; }
        public long? length { get; set; }
        public long? width { get; set; }
        public long? pcn { get; set; }
        public string? pavementType { get; set; }
        public long? maxWeight { get; set; }
        public string? remarks { get; set; }
    }
}
