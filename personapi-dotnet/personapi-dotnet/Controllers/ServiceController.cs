using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Persona> _personaRepository;
        private readonly IRepository<Estudio> _estudioRepository;

        public ServiceController(IRepository<Persona> personaRepository, IRepository<Estudio> estudioRepository)
        {
            _personaRepository = personaRepository;
            _estudioRepository = estudioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> prueba()
        {
            string response = await _estudioRepository.pruebaRepository();

            return Ok(response);
        }
    }
}
