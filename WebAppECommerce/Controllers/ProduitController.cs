using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppECommerce.Data;
using WebAppECommerce.Models;

namespace WebAppECommerce.Controllers
{
    public class ProduitController : Controller
    {
        private readonly AppliDbContext _db;
        public ProduitController(AppliDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Produit> ListProd = _db.Produits;
            return View(ListProd);
        }

        // Methode create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produit p)
        {
            // customisation de la validation des champs de saisie
            if (p.Title == p.Description)
            {
                ModelState.AddModelError("name", "le titre et la description ne doivent pas matcher!");
            }
            if (ModelState.IsValid)
            {
                _db.Produits.Add(p);
                _db.SaveChanges();
                TempData["success"] = "Prod added successeully";

                return RedirectToAction("Index");
            }
            return View(p);
        }

        // implementation  de la methode Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var obj = _db.Produits.Find(id);
            // var obj1 = _db.Produits.SingleOrDefault(a => a.Id == id);
            // var obj2 = _db.Produits.FirstOrDefault(a => a.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produit obj)
        {
            // customisation de la validation des champs de saisie
            if (obj.Title == obj.Description)
            {
                ModelState.AddModelError("name", "le titre et la description ne doivent pas matcher!");
            }

            if (ModelState.IsValid)
            {
                _db.Produits.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Prod update successeully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // implementation  de la methode Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var obj = _db.Produits.Find(id);
            // var obj1 = _db.Produits.SingleOrDefault(a => a.Id == id);
            // var obj2 = _db.Produits.FirstOrDefault(a => a.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Produits.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Produits.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Prod deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
