using System.Collections.Generic;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        TimeEntry Create(TimeEntry timeEntry);
        TimeEntry Find(long id);
        bool Contains(long id);
        IEnumerable<TimeEntry> List();
        TimeEntry  Update(long Id, TimeEntry timeEntry);
        void Delete(long Id);
    }
}