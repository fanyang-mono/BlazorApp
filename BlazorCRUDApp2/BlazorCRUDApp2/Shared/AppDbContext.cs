using BlazorCRUDApp2.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDApp2.Shared
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options)
            : base(options)
        {
        }

        public DbSet <Car> Cars {  get; set; }
    }
}
