using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.Abstract;
using MovieStore.Core.DataTransferObjects;
using MovieStore.Entity.Concrete;
using MovieStore.WebAPI.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : CustomBasesController
    {
        private readonly IMapper _mapper;
        private readonly IService<Actor> _service;
        private IJWTAuthenticationManager _jwtAuthenticationManager;


        public ActorsController(IMapper mapper, IService<Actor> service, IJWTAuthenticationManager jwtAuthenticationManager)
        {
            _mapper = mapper;
            _service = service;
            _jwtAuthenticationManager = jwtAuthenticationManager;

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var actors = await _service.GetAllAsync();
            var actorsDtos = _mapper.Map<List<ActorDto>>(actors.ToList());
            return CreateActionResult(CustomResponseDto<List<ActorDto>>.Success(200, actorsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            var actorsDto = _mapper.Map<ActorDto>(actor);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(200, actorsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ActorDto actorDto)
        {
            var actor = await _service.AddAsync(_mapper.Map<Actor>(actorDto));
            var actorsDto = _mapper.Map<ActorDto>(actor);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(201,actorsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ActorDto actorDto)
        {
            await _service.UpdateAsync(_mapper.Map<Actor>(actorDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(actor);
            var actorsDto = _mapper.Map<ActorDto>(actor);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")] 
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCredential.UserName, userCredential.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);

        }

    }
}
