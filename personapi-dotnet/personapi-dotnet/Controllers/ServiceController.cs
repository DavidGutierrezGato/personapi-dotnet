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


        //-------- CRUD PROFESION --------

        [HttpPost("PostProfesion")]
        public async Task<ActionResult<string>> PostProfesion(ProfesionDTO profesionDTO)
        {

            var response = await _profesionRepository.PostProfesion(profesionDTO);
            if (response.Equals("Guardado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("GetProfesion")]
        public async Task<ActionResult<IEnumerable<Profesion>>> getAllProfesion()
        {
            try
            {
                var response = await _profesionRepository.GetAll();
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("GetProfesion/{id}")]
        public async Task<ActionResult<Telefono>> getProfesion(int id)
        {
            try
            {
                var response = await _profesionRepository.Get(id);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPut("PutProfesion")]
        public async Task<ActionResult<string>> PutProfesion(ProfesionDTO profesion)
        {

            var response = await _profesionRepository.UpdateProfesion(profesion);
            if (response.Equals("Actualizado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DelProfesion")]
        public async Task<ActionResult<string>> DeleteProfesion(int numero)
        {

            var response = await _profesionRepository.RemoveProfesion(numero);
            if (response.Equals("Removido"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        // ----------- CRUD ESTUDIO ---------

        [HttpPost("PostEstudio")]
        public async Task<ActionResult<string>> PostEstudio(EstudiosDTO estudios)
        {

            var response = await _estudioRepository.PostEstudios(estudios);
            if (response.Equals("Guardado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("GetEstudio")]
        public async Task<ActionResult<IEnumerable<Profesion>>> getAllEstudios()
        {
            try
            {
                var response = await _estudioRepository.GetAll();
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("GetEstudio/{id}/{id2}")]
        public async Task<ActionResult<Telefono>> getEstudio(int id,int id2)
        {
            try
            {
                var response = await _estudioRepository.GetEstudios2ID(id,id2);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPut("PutEstudio")]
        public async Task<ActionResult<string>> PutEstudio(EstudiosDTO estudiosDTO)
        {

            var response = await _estudioRepository.UpdateEstudios(estudiosDTO);
            if (response.Equals("Actualizado"))
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DelEstudio")]
        public async Task<ActionResult<string>> DeleteEstudio(int numero, int num2)
        {

            var response = await _estudioRepository.RemoveEstudios(numero, num2);
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
