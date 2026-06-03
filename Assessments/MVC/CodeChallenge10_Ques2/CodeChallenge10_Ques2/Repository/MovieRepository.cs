using CodeChallenge10_Ques2.Models;
using CodeChallenge10_Ques2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge10_Ques2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db = new MovieContext();

        public List<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            var m = db.Movies.Find(movie.Mid);

            m.MovieName = movie.MovieName;
            m.DirectorName = movie.DirectorName;
            m.DateOfRelease = movie.DateOfRelease;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);

            db.Movies.Remove(movie);

            db.SaveChanges();
        }

        public List<Movie> GetMoviesByYear(int year)
        {
            return db.Movies
                     .Where(x => x.DateOfRelease.Year == year)
                     .ToList();
        }

        public List<Movie> GetMoviesByDirector(string director)
        {
            return db.Movies
                     .Where(x => x.DirectorName == director)
                     .ToList();
        }
    }
}