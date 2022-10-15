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
        private readonly IPersonaRepository _personaRepository;
        private readonly IEstudioRepository _estudioRepository;
        private readonly ITelefonoRepository _telefonoRepository;
        private readonly IProfesionRepository _profesionRepository;

        public ServiceController(IPersonaRepository personaRepository,
            IEstudioRepository estudioRepository,
            ITelefonoRepository telefonoRepository,
            IProfesionRepository profesionRepository)
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

        //-------CRUD TELEFONO -----------------------------------------------------

        [HttpGet("GetTelefonos")]
        public async Task<ActionResult<IEnumerable<Telefono>>> getAllTelefonos()
        {
            try
            {
                var response = await _telefonoRepository.GetAll();
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("GetTelefono/{id}")]
        public async Task<ActionResult<Telefono>> getTelefono(int id)
        {
            try
            {
                var response = await _telefonoRepository.Get(id);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("PostTelefono/")]
        public async Task<ActionResult<string>> PostTelefono(Telefono telefono)
        {
            
            var response = await _telefonoRepository.Post(telefono);
            if (response.Equals("Guardado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
                
            
        }

        //------CRUD Persona ---------------------------------------------------
        [HttpPost("PostPersona/")]
        public async Task<ActionResult<string>> PostPersona(Persona persona)
        {

            var response = await _personaRepository.Post(persona);
            if (response.Equals("Guardado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }


        }

    }
}
