using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Data;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesDbContext db = new MoviesDbContext();

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_Index", await this.GetAllMovies());
            }

            return this.View(await this.GetAllMovies());
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = await this.db.Movies.FindAsync(id);
            if (movie == null)
            {
                return this.HttpNotFound();
            }

            return this.View(movie);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Director,Year,LeadMale,LeadFemale,Studio,StudioAddress")] Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Movies.Add(movie);
                await this.db.SaveChangesAsync();

                return this.PartialView("_Index", await this.GetAllMovies());
            }

            return this.View("Index", await this.GetAllMovies());
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = await this.db.Movies.FindAsync(id);
            if (movie == null)
            {
                return this.HttpNotFound();
            }

            return this.PartialView("_Edit", movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Director,Year,LeadMale,LeadFemale,Studio,StudioAddress")] Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(movie).State = EntityState.Modified;
                await this.db.SaveChangesAsync();

                return this.PartialView("_Index", await this.GetAllMovies());
            }

            return this.PartialView("_Index", await this.GetAllMovies());
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await this.db.Movies.FindAsync(id);
            this.db.Movies.Remove(movie);
            await this.db.SaveChangesAsync();

            return this.PartialView("_Index", await this.GetAllMovies());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await this.db.Movies.ToListAsync();
        }
    }
}
