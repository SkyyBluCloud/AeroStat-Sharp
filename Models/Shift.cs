using System;
using System.Collections.Generic;

namespace AeroStat_Sharp
{
    public class Shift
    {
        public long shiftID { get; set; }
        public bool closed { get; set; } = false;
        public long certifierID { get; set; } = 0;
        public string shiftTitle { get; set; }
        public DateTime shiftStart { get; set; }
        public DateTime shiftEnd { get; set; }
        public User superLead { get; set; }
        public List<User> amoc { get; set; }
        public string? remarks { get; set; }
        public string rwy { get; set; }
        public string rsc { get; set; }
        public string rcr { get; set; }
        public string bwc { get; set; }
        public string barrier { get; set; }
        public string tacan { get; set; }
        public string dasr { get; set; }
        public string ils { get; set; }
        public string aarf { get; set; }
        public string? reviewerComments { get; set; }
    }
}
