using MovieManagement.dataAccess;
using MovieManagement.datacontract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMangement.Management
{
    public class MovieManagement
    {
        public object DBContext { get; private set; }

        public List<MovieDTO> search()
        {
            var repo = new MoviesRepository();
            var result = repo.SearchMovies();

            var toReturn = result.Select(a => new MovieDTO
            {
                Id = a.id,
                AverageScore = (float) a.AverageScore,
                CategoryName = a.Category.Name,
                Length = a.Length,
                Rating = a.Rating,
                ReleaseDate = a.ReleaseDate,
                title = a.Title

            }).ToList();
            return toReturn;
        }

        public MovieDTO GetMovie(Guid id)
        {
            var repo = new MoviesRepository();
            var repoResult = repo.GetMovies(id);
            return new MovieDTO
            {
                Id = repoResult.id,
                AverageScore = (float)repoResult.AverageScore,
                CategoryName = repoResult.Category.Name,
                Length = repoResult.Length,
                Rating = repoResult.Rating,
                ReleaseDate = repoResult.ReleaseDate,
                title = repoResult.Title
            };
        }

        
        public void AddOrUpdate(MovieDTO movie)
        {
            var repo = new MoviesRepository();
            if(movie.Id != Guid.Empty)
            {
                var movy = new Movy
                {
                    id = movie.Id,
                    Rating = movie.Rating,
                    Title = movie.title
                };
                repo.UpdateMovie(movy);
            }
            else
            {
                var movy = new Movy
                {
                    id = Guid.NewGuid(),
                    Title = movie.title,
                    AverageScore = movie.AverageScore,
                    Length = movie.Length,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                };
            }
        }

       
    }
}
