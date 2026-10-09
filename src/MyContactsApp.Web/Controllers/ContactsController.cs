using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class ContactsController : Controller
{
    private ContactService _service;
    public static List<Contact> contacts;
    public ContactsController(ContactService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index(string? city, string? state)
    {
        if (!string.IsNullOrWhiteSpace(city))
        {
            contacts = await _service.SearchByCityAsync(city.Trim());
        }
        else if (!string.IsNullOrWhiteSpace(state))
        {
            contacts = await _service.SearchByStateAsync(state.Trim());
        }
        else
        {
            contacts = await _service.GetAllContactsAsync();
        }


        ViewBag.City = city;
        ViewBag.State = state;
        ViewBag.SearchPerformed =
            !string.IsNullOrWhiteSpace(city) ||
            !string.IsNullOrWhiteSpace(state);


        return View(contacts);
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
