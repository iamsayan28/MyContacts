using System;
using System.Collections.Generic;
using System.Text;
public class AddressBook
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = new();
}