using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class ContactsController : Controller
{
    public static List<Contact> ContactList = new List<Contact>();
    
    public IActionResult Index()
    {
        return View(ContactList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        if (!ModelState.IsValid) return View(contact);
        ContactList.Add(contact);
        //ViewData["list"] = _list; //doesnt survive redirect
        return RedirectToAction("Index");
    }
}
