using System;

namespace AeroStat_Sharp
{
    public class User
    {
        public User(string opInitials, string username, string lastName, string firstName, string unit, Rank rank, long? authLevel)
        {
            this.opInitials = opInitials;
            this.username = username;
            this.lastName = lastName;
            this.firstName = firstName;
            this.unit = unit;
            this.rank = rank;
            this.authLevel = authLevel ?? 99;
        }

        public Guid id { get; set; } = Guid.NewGuid();
        public long? spID { get; set; }
        public string opInitials { get; set; }
        public string username { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string fullName3616
        {
            get
            {
                var output = $"{firstName[..1]}. {lastName}/{opInitials}".ToUpper();
                return output;
            }
        }
        public string certName
        {
            get
            {
                var output = $"{firstName}.{lastName}.{username}".ToUpper();
                return output;
            }
        }
        public string? unit { get; set; }
        public Rank rank { get; set; }
        public bool approved { get; set; }
        public DateTime lastLogin { get; set; }
        public string? lastSystem { get; set; }
        public long lastShift { get; set; }
        public bool onShift { get; set; }
        public bool isLoggedIn { get; set; }
        public long authLevel { get; set; }
        public bool spAccess { get; set; }
        public bool BOOT { get; set; }
        public bool RS { get; set; }
        public bool kiosk { get; set; }
    }
}
