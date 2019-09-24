using System;

namespace PalTracker
{
    public struct TimeEntry
    {
        public long? Id {get; set;}   
        public long  ProjectId {get; set;}
        public long UserId {get; set;}
        public DateTime Date {get; set;}
        public int Hours {get; set;}  

        public TimeEntry(int id, int projectId, int userId, DateTime date, int hours)
        {   
            Id = id;        
            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        } 

        public TimeEntry(int projectId, int userId, DateTime date, int hours)
        {    
            Id = null;       
            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        } 

    }
}