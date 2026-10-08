using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Set method isn't usually used, EF core manages setting the DB so prefer the 2nd way which has only get
    //public DbSet<Contact> Contacts { get; set; }

    // Set<Contact> means getting EF core DbSet for Contact entity(which is a collection of Contact records that EF can query and save to the DB)
    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasIndex(c => c.Email).IsUnique();
    }
}

