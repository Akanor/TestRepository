using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ItemPriceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemPriceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ItemPrice> objList = _db.ItemsPrice;
            return View(objList);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemPrice obj)
        {
            if (ModelState.IsValid)
            {
                _db.ItemsPrice.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);            
        }


        //GET Delete
        public IActionResult Delete(int? id)
        {

            if(id == null || id==0)
            {
                return NotFound();
            }

            var obj = _db.ItemsPrice.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST Delete
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ItemsPrice.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.ItemsPrice.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");           
        }


        //GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ItemsPrice.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }


        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ItemPrice obj)
        {
            if (ModelState.IsValid)
            {
                _db.ItemsPrice.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }
}
