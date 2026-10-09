using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
public class AddressBookService
{
    private readonly AppDbContext _context;
    public AddressBookService(AppDbContext context) => _context = context;

    public async Task<int> GetTotalContactCountAsync()
    {
        return await _context.Contacts.CountAsync();
    }
}