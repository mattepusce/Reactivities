using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    //Add-Migration InitialMigration -Project Persistence -StartupProject API
    // Update-Database -Project Persistence -StartupProject API
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<Domain.Activity> Activities { get; set; }
    }
}
