using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IRepository<Persona>
    {
        private readonly persona_dbContext _context;

        public PersonaRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Persona Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Persona> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Post(Persona _object)
        {
            throw new NotImplementedException();
        }

        public void Remove(Persona _object)
        {
            throw new NotImplementedException();
        }

        public void Update(Persona _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            return Task.FromResult("Si funciona personaRepository");
        }
    }
}
