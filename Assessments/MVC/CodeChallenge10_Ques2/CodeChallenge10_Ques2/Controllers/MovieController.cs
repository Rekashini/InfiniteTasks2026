using CodeChallenge10_Ques2.Models;
using CodeChallenge10_Ques2.Repository;
using System.Web.Mvc;

namespace CodeChallenge10_Ques2.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo = new MovieRepository();

        // READ ALL
        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

        // CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // EDIT
        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        // MOVIES BY YEAR
        public ActionResult MoviesByYear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetMoviesByYear(year);
            return View("YearResult", movies);
        }

        // MOVIES BY DIRECTOR
        public ActionResult MoviesByDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetMoviesByDirector(directorName);
            return View("DirectorResult", movies);
        }
    }
}