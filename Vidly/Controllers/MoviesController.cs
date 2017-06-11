using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index(int ? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue) 
                pageIndex=1
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("PageIndex={0} & SortBy={1}",pageIndex,sortBy));
        }
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Gladiator" };
              return View(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home");
            // return RedirectToAction("Index","Home",new { page=1,sortby="Name"});
        }
        public ActionResult Edit(int Id)
            //parameter sources
            //movies/edit/1 embeded
            //movie/edit?Id=1 passing parameter query string
            //by entering in form Id=1
        {
            return Content("ID=" + Id);
        }
    }
}