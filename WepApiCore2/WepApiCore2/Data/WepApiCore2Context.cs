using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WepApiCore2.Models
{
    public class WepApiCore2Context : DbContext
    {
        public WepApiCore2Context (DbContextOptions<WepApiCore2Context> options)
            : base(options)
        {
        }

        public DbSet<WepApiCore2.Models.Movie> Movie { get; set; }
    }
}
