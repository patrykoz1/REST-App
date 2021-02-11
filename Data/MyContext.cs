using Microsoft.EntityFrameworkCore;
using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Data
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article {Id = 1, Title = "Title1",Content ="Content1",CategoryId =1 },
                new Article { Id = 2, Title = "Title2", Content = "Content2", CategoryId = 1 },
                new Article { Id = 3, Title = "Title3", Content = "Content3", CategoryId = 1 });
        }
    }
}
