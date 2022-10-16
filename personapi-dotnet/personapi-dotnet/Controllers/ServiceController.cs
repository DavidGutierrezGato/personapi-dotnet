using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.DTOs;
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
            _profesionRepository = profesionRepository;
        }

        //-------CRUD TELEFONO -----------------------------------------------------

        [HttpGet("GetTelefonos")]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetAllTelefonos()
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
        public async Task<ActionResult<Telefono>> GetTelefono(int id)
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

        [HttpPost("PostTelefono")]
        public async Task<ActionResult<string>> PostTelefono(TelefonoDTO telefono)
        {

            var response = await _telefonoRepository.PostTelefono(telefono);
            if (response.Equals("Guardado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
   
        }

        [HttpPut("PutTelefono")]
        public async Task<ActionResult<string>> PutTelefono(TelefonoDTO telefono)
        {

            var response = await _telefonoRepository.UpdateTelefono(telefono);
            if (response.Equals("Actualizado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DelTelefono")]
        public async Task<ActionResult<string>> DeleteTelefono(string numero)
        {

            var response = await _telefonoRepository.RemoveTelefono(numero);
            if (response.Equals("Removido"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        //------CRUD PERSONA ---------------------------------------------------

        [HttpGet("GetPersonas")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAllPersonas()
        {
            try
            {
                var response = await _personaRepository.GetAll();
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpGet("GetPersona/{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            try
            {
                var response = await _personaRepository.Get(id);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPost("PostPersona")]
        public async Task<ActionResult<string>> PostPersona(PersonaDTO persona)
        {

            var response = await _personaRepository.PostPersona(persona);
            if (response.Equals("Guardado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("PutPersona")]
        public async Task<ActionResult<string>> PutPersona(PersonaDTO persona)
        {

            var response = await _personaRepository.UpdatePersona(persona);
            if (response.Equals("Actualizado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DelPersona")]
        public async Task<ActionResult<string>> DeletePersona(int cedula)
        {

            var response = await _personaRepository.RemovePersona(cedula);
            if (response.Equals("Removido"))
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
