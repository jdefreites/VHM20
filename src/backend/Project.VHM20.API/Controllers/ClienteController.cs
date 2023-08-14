using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.VHM20.API.Helpers;
using Project.VHM20.Data;
using Project.VHM20.Data.Entities;
using Project.VHM20.Data.Persistence.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.VHM20.API.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.FindAllAsync();
            var map = _mapper.Map<List<ClienteDto>>(data);
            return Ok(map);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _repository.FindByIdAsync(id);
            var map = _mapper.Map<ClienteDto>(data);
            return Ok(map);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto value)
        {
            try
            {
                var data = _mapper.Map<Cliente>(value);
                await _repository.AddAsync(data);
                await _repository.CommitAsync();

                return StatusCode(StatusCodes.Status201Created, new { results = "Registro creado" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteDto value)
        {
            try
            {
                var data = _mapper.Map<Cliente>(value);
                await _repository.UpdateAsync(data);
                await _repository.CommitAsync();

                return Ok(new { result = "Registro actualizado" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _repository.FindByIdAsync(id);
                await _repository.DeleteAsync(data);
                await _repository.CommitAsync();

                return StatusCode(StatusCodes.Status200OK, new { result = "Registro eliminado" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
            }
        }
    }
}
