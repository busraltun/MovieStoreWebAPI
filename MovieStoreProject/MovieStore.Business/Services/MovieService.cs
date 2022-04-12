using AutoMapper;
using MovieStore.Core.Abstract;
using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IGenericRepository<Movie> repository, IUnitOfWork unitOfWork, IMapper mapper, IMovieRepository movieRepository ) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector()
        {
            var movies = await _movieRepository.GetMovieWithDirector();
            var moviesDto = _mapper.Map<List<MovieWithDirectorDto>>( movies );
            return CustomResponseDto<List<MovieWithDirectorDto>>.Success(200, moviesDto);
        }
    }
}
