using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Contact
{
    public int Id { get; set; }
    [RegularExpression("^[A-Z][a-zA-Z]{2,}$")]
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [RegularExpression("^.{4,}$")]
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    [RegularExpression("^[0-9]{6}$")]
    public string Zip { get; set; } = string.Empty;
    [RegularExpression("^[0 - 9]{10}$")]
    public string PhoneNumber { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} | {Address}, " +
                $"{City}, {State} {Zip} | {PhoneNumber} | {Email}";
    }
    // without override, it wouldn't behave well polymorphically(cases like Blazor data binding, String.Format,
    // logger outputs, or list displays evaluate an object via ToString())
}