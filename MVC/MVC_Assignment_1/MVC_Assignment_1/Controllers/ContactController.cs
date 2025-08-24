using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_Assignment_1.Repositories;
using MVC_Assignment_1.Models;

namespace MVC_Assignment_1.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController()
        {
            _repository = new ContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}