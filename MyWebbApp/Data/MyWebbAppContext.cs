using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebbApp.Models;

namespace MyWebbApp.Data
{
    public class MyWebbAppContext : DbContext
    {
        public MyWebbAppContext (DbContextOptions<MyWebbAppContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebbApp.Models.My_Projects_Model> My_Projects_Model { get; set; } = default!;
    }
}
