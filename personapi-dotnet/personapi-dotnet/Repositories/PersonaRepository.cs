using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
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
    }
}
