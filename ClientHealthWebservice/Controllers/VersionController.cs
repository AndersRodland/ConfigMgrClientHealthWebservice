using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientHealthWebservice.Controllers
{
    public class VersionController : Controller
    {
        // GET: Version
        public string Index()
        {
            string version = "2.1";
            return version;
        }

        /*
        // GET: Version/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Version/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Version/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Version/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Version/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Version/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Version/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
