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
    public async Task<bool> AddContactServiceAsync(Contact contact)
    {
        contact.FirstName = contact.FirstName.Trim();
        contact.LastName = contact.LastName.Trim();

        bool exists = await _context.Contacts.AnyAsync(c => c.FirstName == contact.FirstName && c.LastName == contact.LastName);

        if (exists)
        {
            return false;
        }

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact?> FindContactByIdASync(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null) return false;

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Contact>> SearchByCityAsync(string city)
    {
        city = city.Trim();

        return await _context.Contacts.Where(c => c.City.Contains(city)).ToListAsync();
    }

    public async Task<List<Contact>> SearchByStateAsync(string state)
    {
        state = state.Trim();

        return await _context.Contacts.Where(c => c.State.Contains(state)).ToListAsync();
    }

}
