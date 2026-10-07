using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Contact
{
    public int Id { get; set; }
    [Required(ErrorMessage =("First Name is required"))]
    [RegularExpression("^[A-Z][a-zA-Z]{2,}$")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = ("Last Name is required"))]
    [RegularExpression("^[A-Z][a-zA-Z]{2,}$")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = ("Address is required"))]
    [RegularExpression("^.{4,}$")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = ("City is required"))]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = ("State is required"))]
    public string State { get; set; } = string.Empty;

    [Required(ErrorMessage = ("Zip is required"))]
    [RegularExpression("^[0-9]{6}$")]
    public string Zip { get; set; } = string.Empty;

    [Required(ErrorMessage = ("Phone Number is required"))]
    [RegularExpression("^[0-9]{10}$")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = ("Email is required"))]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{FirstName} {LastName} | {Address}, " +
                $"{City}, {State} {Zip} | {PhoneNumber} | {Email}";
    }
}