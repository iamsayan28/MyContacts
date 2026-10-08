using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class ContactsController : Controller
{
    private ContactService _service;
    public static List<Contact> ContactList;
    public ContactsController(ContactService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        ContactList = await _service.GetAllContactsAsync();
        return View(ContactList);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
}
