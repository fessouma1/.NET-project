using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.dataAccess
{
    public class MoviesRepository : BaseRepository
    {
        public List<Movy> SearchMovies()
        {
            return DBContext.Movies.ToList();
        }

        public Movy GetMovies(Guid MoviesId)
        {

            var movies = DBContext.Movies.FirstOrDefault(a => a.id == MoviesId);
            return movies;

        }

        public void AddMovy(Movy NewMovy)
        {

            DBContext.Movies.Add(NewMovy);
            DBContext.SaveChanges();

        }

        public void DeleteMovy(Guid movyId)
        {

            var movies = DBContext.Movies.FirstOrDefault(a => a.id == movyId);
            if (movies != null)
            {
                DBContext.Movies.Remove(movies);
                DBContext.SaveChanges();
            }
        }

        public void UpdateMovie(Movy updatedMovy)
        {

            var existingMovy = DBContext.Movies.FirstOrDefault(a => a.id == updatedMovy.id);
            if (existingMovy != null)
            {
                existingMovy.Title = updatedMovy.Title;
                DBContext.SaveChanges();
            }
        }
    }

}

