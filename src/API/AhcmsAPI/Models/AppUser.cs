﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhcmsAPI.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public bool IsAdmin { get; set; }
    }
}
