using System;
using System.Collections.Generic;
using System.Linq;
using AeroStat_Sharp.Properties;

namespace AeroStat_Sharp.Models
{
    public class PPR
    {
        
        public PPR() { }
        //public PPR(string amops, string callsign, int number, string type, string tail, List<PPRService> services,
        //    string depPoint, DateTime arrDate, DateTime? depDate, string? destination,
        //    string? crew, long? paxOn, long? paxOff, long? cargoOn, long? cargoOff, CargoUnit? cargoUnit,
        //    Spot? spot, string? fuel, FuelUnit? fuelUnit, string? remarks,
        //    string? dvCode, string? unit, string? pocName, string? ctcInfo, string? msn)
        //{
        //    newRec = true;
        //    this.pprNumber = autoPPR();

        //    this.amops = amops;
        //    this.callsign = callsign;
        //    this.number = number;
        //    this.type = type;
        //    this.tail = tail;
        //    this.services = services;

        //    this.depPoint = depPoint;
        //    this.arrDate = arrDate;
        //    this.depDate = depDate;
        //    this.destination = destination;

        //    this.crew = crew;
        //    this.paxOn = paxOn;
        //    this.paxOff = paxOff;
        //    this.cargoOn = cargoOn;
        //    this.cargoOff = cargoOff;
        //    this.cargoUnit = cargoUnit;

        //    this.spot = spot;
        //    this.fuel = fuel;
        //    this.fuelUnit = fuelUnit;
        //    this.remarks = remarks;

        //    this.dvCode = dvCode;
        //    this.unit = unit;
        //    this.pocName = pocName;
        //    this.ctcInfo = ctcInfo;
        //    this.msn = msn;
        //}
        public void loadServices()
        {
            if (this.services != null)
            {
                var svc = this.services.Split(",");
                DataAccess DA = new();
                List<PPRService> pprServices = DA.getPPRServices();

                pprServices.ForEach((p) =>
                {
                    svc.ToList().ForEach((i) =>
                    {
                        p.requested = i == p.id.ToString();
                    });
                });

                this.pprServices = pprServices;
                this.services = null;
            }
        }

        public static string autoPPR()
        {
            DataAccess da = new();
            string ppr = $"{DateTime.Now.Year:yy}-{("ZZ").ToUpper()}{da.getLastPPR("ZZ") + 1:000}";
            return ppr;
        }

        public bool newRec { get; set; } = false;
        public DateTime arrDate { get; set; }
        public string formatArrDate => arrDate.ToString(Settings.Default.dateFormat);
        public string? formatDepDate => depDate?.ToString(Settings.Default.dateFormat);
        public string? amops { get; set; }
        public string? pprNumber { get; set; }
        public List<Traffic>? trafficStrips { get; set; }
        public List<PPRService>? pprServices { get; set; }
        public string? services { get; set; }
        public enum CargoUnit
        {
            KIPS,
            LBS,
            SINGLES,
            PALLETS,
            KGS
        }
        public CargoUnit? cargoUnit { get; set; }
        public enum PPRStatus
        {
            Completed,
            Approved,
            Pending,
            Cancelled
        }
        public enum FuelUnit
        {
            GAL,
            LBS,
            KGS,
            TRUX //50k gal?
        }
        public FuelUnit? fuelUnit { get; set; }

        //Table values
        public Guid id { get; set; } = new();
        public Guid? certifierID { get; set; }
        public DateTime? issueDate { get; set; }
        public DateTime lastUpdate { get; set; } = DateTime.Now;
        public string? lastUser { get; set; }
        public long spID { get; set; } = 0;
        public PPRStatus status { get; set; } = PPRStatus.Pending;
        public string? callsign { get; set; }
        public long number { get; set; } = 1;
        public string? type { get; set; }
        public string? tail { get; set; }
        public string? depPoint { get; set; }
        public DateTime? depDate { get; set; }
        public string? destination { get; set; }
        public Spot? spot { get; set; }
        public string? fuel { get; set; }
        public string? remarks { get; set; }
        public string? dvCode { get; set; }
        public string? crew { get; set; }
        public long? paxOn { get; set; } = 0;
        public long? paxOff { get; set; } = 0;
        public long? cargoOn { get; set; } = 0;
        public long? cargoOff { get; set; } = 0;
        public string? unit { get; set; }
        public string? pocName { get; set; }
        public string? ctcInfo { get; set; }
        public long approval { get; set; } = 0;
        public string? msn { get; set; }
        public bool archive { get; set; } = false;
    }
}
