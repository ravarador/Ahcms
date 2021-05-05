using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhcmsAPI.Models
{
    public class AhcmsContext : DbContext
    {
        public AhcmsContext(DbContextOptions<AhcmsContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
