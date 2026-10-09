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

    public IActionResult Add()
    {
        return View();
    }

    public IActionResult Edit(int id)
    {
        return View(id);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteContactAsync(id);
        return RedirectToAction("Index");
    }
}
