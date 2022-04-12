using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.Abstract;
using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : CustomBasesController
    {

        private readonly IMapper _mapper;
        private readonly IService<Director> _service;

        public DirectorsController(IMapper mapper, IService<Director> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var directors = await _service.GetAllAsync();
            var directorsDtos = _mapper.Map<List<DirectorDto>>(directors.ToList());
            return CreateActionResult(CustomResponseDto<List<DirectorDto>>.Success(200, directorsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director = await _service.GetByIdAsync(id);
            var directorsDtos = _mapper.Map<DirectorDto>(director);
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(200, directorsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DirectorDto directorDto)
        {
            var director = await _service.AddAsync(_mapper.Map<Director>(directorDto));
            var directorsDtos = _mapper.Map<DirectorDto>(director);
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(201, directorsDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DirectorDto directorDto)
        {
            await _service.UpdateAsync(_mapper.Map<Director>(directorDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var director = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(director);
            var directorsDto = _mapper.Map<DirectorDto>(director);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
