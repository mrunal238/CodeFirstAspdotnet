using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApproach1.Models;
namespace EFCodeFirstApproach1.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create() {
        return View();
        
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            {
                if(ModelState.IsValid == true)
                {
                    db.Students.Add(s);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {

                        ///ViewBag.InsertMessage = "<script>alert('data inserted !!!')</script>";
                        TempData["InsertMessage"]= "<script>alert('data inserted !!!')</script>";
                        //ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                    else

                    {

                        ViewBag.InsertMessage = "<script>alert('data not  inserted !!!')</script>";

                    }

                }
            }
            
            
            return View();

        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
           int a = db.SaveChanges();
            if (a>0)
            {
                 ViewBag.UpdateMessage = "<script>alert('data updated !!!')</script>";
                //TempData["UpdateMessage"] = "<script>alert('data updated !!!')</script>";
                //return RedirectToAction("Index");
               ModelState.Clear();

            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('data not  updated !!!')</script>";
            }
            return View();

        }
        public ActionResult Delete(int id)
        {
            var StudentIdRow = db.Students.Where(model => model.Id == id).FirstOrDefault(); 
            return View(StudentIdRow);

        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State= EntityState.Deleted;
            int a = db.SaveChanges();
            if (a>0)
            {
                TempData["DeleteMessage"] = "<script>alert('data deleted !!!')</script>";
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('data not  deleted !!!')</script>";
            }
            return RedirectToAction("Index");
        }
    }

}