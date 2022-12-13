using AeroStat_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroStat_Sharp
{
    public class Traffic
    {
        public enum flightStatus
        {
            PENDING,
            ENROUTE,
            CLOSED,
            CANCELLED
        }
        public enum flightRule
        {
            I,
            V,
            Y,
            Z,
            S
        }
        public enum fileMethod
        {
            DD1801,
            EFILE,
            FPNO
        }
        public DateTime entryDate { get; set; }
        public Shift shift { get; set; }
        public Guid id { get; set; }
        public Guid certifierID { get; set; }
        public PPR? ppr { get; set; }
        public User user { get; set; }
        public string callsign { get; set; }
        public int number { get; set; } = 1;
        public string acType { get; set; }
        public Traffic.flightStatus status { get; set; }
        public Traffic.flightRule rule { get; set; } = flightRule.I;
        public string depPoint { get; set; }
        public string destination { get; set; }
        public Traffic.fileMethod fpType { get; set; } = fileMethod.DD1801;
        public DateOnly dof { get; set; }
        public TimeOnly etd { get; set; }
        public TimeOnly ete { get; set; }
        public TimeOnly? eta { get; set; }
        public TimeOnly? atd { get; set; }
        public TimeOnly? ata { get; set; }
        public long altitude { get; set; }
        public string? tail { get; set; }
        public long rwy { get; set; }
        public string remarks { get; set; }


    }
}
