using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IRepository<Profesion>
    {

        private readonly persona_dbContext _context;

        public ProfesionRepository(persona_dbContext context)
        {
            _context = context;
        }


        public Task<Profesion> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profesion>> GetAll()
        {
            IEnumerable<Profesion> response = _context.Profesions.ToList();
            return Task.FromResult(response);

        }

        public void Post(Profesion _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            throw new NotImplementedException();
        }

        public void Remove(Profesion _object)
        {
            throw new NotImplementedException();
        }

        public void Update(Profesion _object)
        {
            throw new NotImplementedException();
        }
    }
}
