using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly persona_dbContext _context;

        public PersonaRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Task<Persona> Get(int id)
        {
            var response = _context.Personas.FirstOrDefault(x => x.Cc == id);
            return Task.FromResult(response);
        }

        public Task<IEnumerable<Persona>> GetAll()
        {
            IEnumerable<Persona> response = _context.Personas.ToList();
            return Task.FromResult(response);

        }

        public Task<string> Post(Persona _object)
        {
            try
            {
                _context.Personas.Add(_object);
                _context.SaveChanges();
                return Task.FromResult("Guardado");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> Remove(Persona _object)
        {
            try
            {
                _context.Personas.Remove(_object);
                _context.SaveChanges();
                return Task.FromResult("Removido");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> Update(Persona _object)
        {
            try
            {
                _context.Entry(_object).State = EntityState.Modified;
                _context.SaveChanges();
                return Task.FromResult("Actualizado");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> pruebaRepository()
        {
            return Task.FromResult("Si funciona personaRepository");
        }

        public Task<string> PostPersona(PersonaDTO _object)
        {
            try
            {
                Persona persona = new Persona();
                persona.Apellido = _object.Apellido;
                persona.Nombre = _object.Nombre;
                persona.Edad = _object.Edad;
                persona.Cc = _object.Cc;
                persona.Genero = _object.Genero;

                _context.Personas.Add(persona);
                _context.SaveChanges();
                return Task.FromResult("Guardado");
                
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> RemovePersona(int cc)
        {
            try
            {
                var persona = _context.Personas.Where(x => x.Cc == cc).Include(x => x.Estudios).Include(x => x.Telefonos).First();
                if (persona != null)
                {
                    _context.Telefonos.RemoveRange(persona.Telefonos);
                    _context.Estudios.RemoveRange(persona.Estudios);
                    _context.Personas.Remove(persona);
                    _context.SaveChanges();
                    return Task.FromResult("Removido");
                }
                return Task.FromResult("Error");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> UpdatePersona(PersonaDTO _object)
        {
            try
            {
                var persona = _context.Personas.FirstOrDefault(x => x.Cc == _object.Cc);

                if (persona != null)
                {
                    persona.Edad = _object.Edad;
                    persona.Apellido = _object.Apellido;
                    persona.Nombre = _object.Nombre;
                    persona.Genero = _object.Genero;

                    _context.Entry(persona).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Task.FromResult("Actualizado");
                }
                else
                {
                    return Task.FromResult("Error");
                }
            }
            catch
            {
                return Task.FromResult("Error");
            }
            
        }
    }
}
