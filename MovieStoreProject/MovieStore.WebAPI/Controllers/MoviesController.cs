using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.Abstract;
using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using MovieStore.WebAPI.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : CustomBasesController
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesController(IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        //[HttpGet("GetMovieWithDirector")]
        [HttpGet("action")]
        public async Task<IActionResult> GetMovieWithDirector()
        {
            return CreateActionResult(await _movieService.GetMovieWithDirector());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await _movieService.GetAllAsync();
            var moviesDtos = _mapper.Map<List<MovieDto>>(movies.ToList());
            return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200, moviesDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            var moviesDto = _mapper.Map<MovieDto>(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(200, moviesDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            var movie = await _movieService.AddAsync(_mapper.Map<Movie>(movieDto));
            var moviesDto = _mapper.Map<MovieDto>(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(201, moviesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MovieDto movieDto)
        {
            await _movieService.UpdateAsync(_mapper.Map<Movie>(movieDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            await _movieService.RemoveAsync(movie);
            var moviesDto = _mapper.Map<MovieDto>(movie);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
