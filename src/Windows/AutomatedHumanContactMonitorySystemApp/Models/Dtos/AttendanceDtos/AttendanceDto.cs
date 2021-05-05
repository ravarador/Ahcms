﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public DateTime VisitedDateTime { get; set; }
        public double Temperature { get; set; }
        public string Status { get; set; }
        #region Attendee
        public int AttendeeId { get; set; }
        public long AttendeeRFID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string AttendeeStatus { get; set; }
        public string ContactNumber { get; set; }
        #endregion
        #region Place
        public int PlaceId { get; set; }
        public string Location { get; set; }
        #endregion
    }
}
