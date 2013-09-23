using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;
using PhoneBook.DAL;

namespace PhoneBook.Controllers
{
    public class AbonentController : Controller
    {
        private PhoneBookDb db = new PhoneBookDb();

        //
        // GET: /Abonent/

        public ActionResult Index()
        {
            return View(db.Abonents.ToList());
        }

        //
        // GET: /Abonent/Details/5

        public ActionResult Details(int id = 0)
        {
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return HttpNotFound();
            }
            return View(abonent);
        }

        //
        // GET: /Abonent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Abonent/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Abonent abonent)
        //{
        //    //List<Number> numbersList = new List<Number>();
        //    if (ModelState.IsValid)
        //    {
        //        db.Abonents.Add(abonent);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return null;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tuple<Abonent, Number> abonent)
        {
            Abonent abon = new Abonent();
            Number numb = new Number();
            //List<Number> numbersList = new List<Number>();
            if (ModelState.IsValid)
            {
                abon.LastName = abonent.Item1.LastName;
                abon.FirstName = abonent.Item1.FirstName;
                abon.Birthday = abonent.Item1.Birthday;
                numb.Phone = abonent.Item2.Phone;
                //db.Abonents.Add(abonent.Item1);
                //db.Numbers.Add(abonent.Item2);
                db.Abonents.Add(abon);
                db.Numbers.Add(numb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abonent);
        }


        //
        // GET: /Abonent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return HttpNotFound();
            }
            return View(abonent);
        }

        //
        // POST: /Abonent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abonent);
        }

        //
        // GET: /Abonent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return HttpNotFound();
            }
            return View(abonent);
        }

        //
        // POST: /Abonent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abonent abonent = db.Abonents.Find(id);
            db.Abonents.Remove(abonent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}