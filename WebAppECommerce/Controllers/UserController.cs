using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppECommerce.Data;
using WebAppECommerce.Models;

namespace WebAppECommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly AppliDbContext _db;
        public UserController(AppliDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> ListUser = _db.users;
            return View(ListUser);
        }
        //implementation de la methode create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _db.users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(user);
        }

        // implementation de la methode Edit
        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EditedObj = _db.users.Find(id);
            if (EditedObj == null) { return NotFound(); }
            return View(EditedObj);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // implementation de la methode Edit
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EditedObj = _db.users.Find(id);
            if (EditedObj == null) { return NotFound(); }
            return View(EditedObj);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var DeletedObj = _db.users.Find(id);
            if (id != 0)
            {
                _db.users.Remove(DeletedObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(DeletedObj);
        }
    }
}

