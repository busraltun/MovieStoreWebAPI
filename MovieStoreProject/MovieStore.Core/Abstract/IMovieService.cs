using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Abstract
{
    public interface IMovieService : IService<Movie>
    {
        Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector();

    }
}
