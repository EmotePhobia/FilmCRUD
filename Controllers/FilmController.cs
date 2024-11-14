using FilmAplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmAplication.Controllers
{
    public class FilmController : Controller
    {
        // GET: FilmController

        private static IList<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "Opis filmu1", Price = 3},
            new Film(){Id = 2, Name = "Film2", Description = "Opis filmu2", Price = 5},
            new Film(){Id = 3, Name = "Film3", Description = "Opis filmu3", Price = 3},
        };
        public ActionResult Index()
        {
            return View(films);
            
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {

            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);    
            return RedirectToAction(nameof(Index));
            
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film film1 = films.FirstOrDefault(x => x.Id == id);
            film1.Name = film.Name;
            film1.Description = film.Description;
            film1.Price = film.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film film)
        {
            Film film1 = films.FirstOrDefault(x => x.Id == id);
            films.Remove(film1);
            return RedirectToAction(nameof(Index));

        }
    }
}
