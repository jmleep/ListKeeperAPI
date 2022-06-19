using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListKeeperAPI.Models;

namespace ListKeeperAPI.Data
{
    public class ListKeeperAPIContext : DbContext
    {
        public ListKeeperAPIContext (DbContextOptions<ListKeeperAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ListKeeperAPI.Models.LKParentList>? LKParentList { get; set; }

        public DbSet<ListKeeperAPI.Models.LKSubList>? LKSubList { get; set; }

        public DbSet<ListKeeperAPI.Models.LKTask>? LKTask { get; set; }
    }
}
