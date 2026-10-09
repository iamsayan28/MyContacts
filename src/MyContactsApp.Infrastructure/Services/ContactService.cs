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

    public async Task<bool> UpdateContactAsync(Contact contact)
    {
        contact.FirstName = contact.FirstName.Trim();
        contact.LastName = contact.LastName.Trim();

        // Constraint: Cannot update to a name that already belongs to another contact
        bool duplicate = await _context.Contacts.AnyAsync(c =>
            c.Id != contact.Id &&
            c.FirstName == contact.FirstName &&
            c.LastName == contact.LastName);

        if (duplicate)
        {
            return false;
        }

        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
        return true;
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
    // UC 10 — Count by City or State
    public async Task<Dictionary<string, int>> GetCountByCityAsync()
    {
        return await _context.Contacts
            .GroupBy(c => c.City)
            .Select(g => new { City = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.City, x => x.Count);
    }
    public async Task<Dictionary<string, int>> GetCountByStateAsync()
    {
        return await _context.Contacts
            .GroupBy(c => c.State)
            .Select(g => new { State = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.State, x => x.Count);
    }
    // UC 11 — Sort Entries by Name
    public async Task<List<Contact>> SortByNameAsync()
    {
        return await _context.Contacts
            .OrderBy(c => c.FirstName)
            .ThenBy(c => c.LastName)
            .ToListAsync();
    }

    // UC 12 — Sort by City, State, or Zip
    public async Task<List<Contact>> SortByCityAsync()
    {
        return await _context.Contacts
            .OrderBy(c => c.City)
            .ToListAsync();
    }
    public async Task<List<Contact>> SortByStateAsync()
    {
        return await _context.Contacts
            .OrderBy(c => c.State)
            .ToListAsync();
    }
    public async Task<List<Contact>> SortByZipAsync()
    {
        return await _context.Contacts
            .OrderBy(c => c.Zip)
            .ToListAsync();
    }
}
