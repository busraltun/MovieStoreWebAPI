using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MovieStore.Core.Abstract;
using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieStore.Caching
{
    public class MovieServiceWithCaching : IMovieService
    {
        private const string CacheMovieKey = "moviesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieServiceWithCaching(IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _memoryCache = memoryCache;
            _mapper = mapper;


            if (!memoryCache.TryGetValue(CacheMovieKey, out _))
            {
                _memoryCache.Set(CacheMovieKey, _movieRepository.GetAll().ToList());
            }
        }

        public async Task<Movie> AddAsync(Movie entity)
        {
            await _movieRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
            return entity;
        }

        public async Task<IEnumerable<Movie>> AddRangeAsync(IEnumerable<Movie> entities)
        {
            await _movieRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Movie, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<Movie> GetByIdAsync(int id)
        //{
        //    return ;
        //    //return Task.FromResult(
        //    //    //_memoryCache.Get<List<Movie>>(CacheMovieKey)
        //    //    //            .From);
        //}

        public Task<CustomResponseDto<List<MovieWithDirectorDto>>> GetMovieWithDirector()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Movie entity)
        {
            _movieRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();

        }

        public async Task RemoveRangeAsync(Movie entities)
        {
            _movieRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            _movieRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
        }

        public IQueryable<Movie> Where(Expression<Func<Movie, bool>> expression)
        {
            return _memoryCache.Get<List<Movie>>(CacheMovieKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllMoviesAsync()
        {
            _memoryCache.Set(CacheMovieKey, await _movieRepository.GetAll().ToListAsync());
       
            //Her çağırdığımızda sıfırdan datayı çekip cacheliyor
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
