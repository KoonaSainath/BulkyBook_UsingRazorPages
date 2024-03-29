﻿using BulkyBook_UsingRazorPagesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook_UsingRazorPagesWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
