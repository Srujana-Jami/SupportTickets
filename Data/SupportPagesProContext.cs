using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportPagesPro.Models;

namespace SupportPagesPro.Data
{
    public class SupportPagesProContext : DbContext
    {
        public SupportPagesProContext (DbContextOptions<SupportPagesProContext> options)
            : base(options)
        {
        }

        public DbSet<SupportPagesPro.Models.SupportTicket> SupportTicket { get; set; }
    }
}
