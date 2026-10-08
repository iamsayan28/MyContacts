using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

public class ContactService
{
    private readonly AppDbContext _context;
    public ContactService(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddContactServiceAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        return await _context.Contacts.ToListAsync();
    }
}
