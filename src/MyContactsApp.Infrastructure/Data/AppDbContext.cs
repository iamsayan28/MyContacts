using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


public class AppDbContext : DbContext
{
    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Contact> Contacts { get; set; };
    //public DbSet<Contact> Contacts => Set<Contact>();
    // public DbSet<AddressBook> AddressBooks => Set<AddressBook>(); // UC6+


}

