using System;
using System.Collections.Generic;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDictionary<long, TimeEntry> _timeEntries = new Dictionary<long, TimeEntry>();

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var id = _timeEntries.Count + 1;

            timeEntry.Id = id;

            _timeEntries.Add(id, timeEntry);

            return timeEntry;
        }

        public TimeEntry Find(long id) => _timeEntries[id];
       
        public bool Contains(long id) => _timeEntries.ContainsKey(id);
        
        public IEnumerable<TimeEntry> List() => _timeEntries.Values;
        
        public TimeEntry Update(long Id, TimeEntry timeEntry)
        {
            timeEntry.Id = Id;            
            _timeEntries[Id] = timeEntry;            
            return timeEntry;
        }
        public  void Delete(long Id)
        {
            _timeEntries.Remove(Id);
        }
    }
}