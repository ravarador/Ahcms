using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Models.ContextModels
{
    public class Attendee
    {
        public int Id { get; set; }
        public long AttendeeRFID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string ContactNumber { get; set; }
    }
}
