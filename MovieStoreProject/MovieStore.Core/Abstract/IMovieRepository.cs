using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Abstract
{
    public interface IMovieRepository : IGenericRepository<Movie> 
    {
        Task<List<Movie>> GetMovieWithDirector();
    }
}
