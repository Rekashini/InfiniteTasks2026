using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge10_Ques2.Models;

namespace CodeChallenge10_Ques2.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        List<Movie> GetMoviesByYear(int year);
        List<Movie> GetMoviesByDirector(string director);
    }
}