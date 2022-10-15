using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Persona> _personaRepository;
        private readonly IRepository<Estudio> _estudioRepository;
        private readonly IRepository<Telefono> _telefonoRepository;
        private readonly IRepository<Profesion> _profesionRepository;

        public ServiceController(IRepository<Persona> personaRepository,
            IRepository<Estudio> estudioRepository,
            IRepository<Telefono> telefonoRepository,
            IRepository<Profesion> profesionRepository)
        {
            _personaRepository = personaRepository;
            _estudioRepository = estudioRepository;
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> prueba()
        {
            string response = await _estudioRepository.pruebaRepository();

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<string>> getAllTelefonos()
        {
            var response = await _telefonoRepository.GetAll();

            return Ok(response);
        }


    }
}
