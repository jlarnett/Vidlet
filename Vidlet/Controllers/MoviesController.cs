using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlet.Models;
using Vidlet.ViewModels;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace Vidlet.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            //Creates new Application DBContext object.
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //Disposes of db context object. Overrides base displose method. 
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
            {
                return HttpNotFound();
            }

            return View(movies);
        }
    }
}