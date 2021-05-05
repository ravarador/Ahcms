using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Models.Dtos
{
    public class SearchDto
    {
        public string SearchBy { get; set; }
        public string SearchText { get; set; }
        public DateTime? Date { get; set; }
        public int? PlaceId { get; set; }
    }
}
