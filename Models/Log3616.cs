using System;
using System.Collections.Generic;

namespace AeroStat_Sharp
{
    public class Log3616
    {
        public long id { get; set; }
        public Shift shift { get; set; }
        public long certifierid { get; set; } = 0;
        public DateTime dateCreated { get; set; } = DateTime.Now;
        public User createdBy { get; set; }
        public bool archive { get; set; } = false;
        public string? archiveBy { get; set; }
        public DateTime? archivetime { get; set; }
        public List<Entry> entries { get; set; } = new List<Entry>();
        public class Entry
        {
            private long id { get; set; }
            private Log3616 log3616 { get; set; }
            private string text { get; set; }
            private DateTime? entryTime { get; set; } = DateTime.Now;
            private User user { get; set; }
            private bool archive { get; set; } = false;
            private User? archiveBy { get; set; }
            private DateTime? archiveTime { get; set; }

            internal Entry(Log3616 _log3616, string _text, DateTime? _entryTime, User _user)
            {
                log3616 = _log3616;
                text = _text;
                entryTime = _entryTime;
                user = _user;
            }
        }

        public Log3616 (Shift _shift, User _createdBy)
        {
            shift = _shift;
            createdBy = _createdBy;
        }
        public Entry newEntry(string _text, DateTime? _entryTime, User _user )
        {
            Entry entry = new Entry(this, _text, _entryTime, _user);
            entries.Add (entry);
            return entry;
        }
    }
}
