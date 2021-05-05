using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhcmsAPI.Models.Dtos
{
    public class SearchDto
    {
        public string SearchBy { get; set; }
        public string SearchText { get; set; }
        public DateTime? Date { get; set; }
        public int? PlaceId { get; set; }
    }
}
