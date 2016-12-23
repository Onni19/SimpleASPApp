

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleASPApp.Models;

namespace SimpleASPApp.Controllers
{
    public class PeopleController : Controller
    {

     private ContextEntites db =new ContextEntites();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.ToList();
            return View(people);
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {

            var person = db.People.Find(id);
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(Person people)
        {
            try
            {
                // TODO: Add insert logic here

                //check from database data saves or not 
                if (ModelState.IsValid)
                {
                    db.People.Add(people); //INSERT INTO
                    db.SaveChanges();// multiple data can add this feature

                    return RedirectToAction("Index");// we will b successful come back to index
                }
                
            }
            catch
            {
               throw new Exception("Sorry Data did not Save");
            }
            return View(people);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            var person = db.People.Find(id); // select top 1 * from person where PersonID=id 
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(person).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();// database execute the update command

                    return RedirectToAction("Index");
                }
               
            }
            catch
            {
             throw new Exception("Sorry We could not save the Updated data");
            }

            return View(person);

        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {

            var person = db.People.Find(id); // select top 1 * from person where PersonID=id 
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(Person person)
        {
            try
            {
                // TODO: Add delete logic here
                person = db.People.Find(person.PersonId); // select top 1 * from person where PersonID=id .here find the person

                db.Entry(person).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                throw new Exception("Sorry not deleted");
            }

           
        }

        public ActionResult Search(string query)
        {
            var splitTexts = query.Split(' ');
            var people = db.People
                .Where(person =>
                        splitTexts
                            .Any(querySingle => //like '*query*'
                                    person.FirstName.Contains(querySingle)) ||
                        splitTexts
                            .Any(querySingle =>
                                    person.LastName.Contains(querySingle)) ||
                        splitTexts
                            .Any(querySingle =>
                                    person.Address.Contains(querySingle))

                    //why ???
                    // ||   splitTexts
                    //   .Any(querySingle =>
                    //       person.DateOfBirth.Contains(querySingle)) 

                ); //entity 
            return View("Index",people); //people came from Personcontroller in index method

        }
    }
}
