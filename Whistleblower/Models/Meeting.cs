using System;

namespace Whistleblower.Models
{
    public class Meeting
    {
        public string Title { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool InPerson { get; set; }

        public Meeting (string title, DateTime scheduledTime, bool inPerson) {
            Title = title;
            ScheduledTime = scheduledTime;
            InPerson = inPerson;
        }
    }

}