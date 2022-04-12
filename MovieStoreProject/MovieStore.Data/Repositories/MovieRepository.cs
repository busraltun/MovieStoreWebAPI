using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Abstract;
using MovieStore.Data.ContextConfiguration;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(Context context) : base(context)
        {

        }
        public async Task<List<Movie>> GetMovieWithDirector()
        {
            //Eager Loading
            return await _context.Movies.Include(m => m.Director).ToListAsync();
        }
    }
}
