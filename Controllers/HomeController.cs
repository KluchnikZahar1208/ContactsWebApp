using ContactsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ContactsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            db.Contacts.Add(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact != null)
            {
                return PartialView("Edit", contact);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Contact b = db.Contacts.Find(id);
            if (b != null)
            {
                db.Contacts.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return View();
            }
            return View(contact);
        }
    }
}