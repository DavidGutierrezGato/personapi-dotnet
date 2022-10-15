using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IRepository<Estudio>
    {
        private readonly persona_dbContext _context;

        public EstudioRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Task<Estudio> Get(int idProf)
        {
            var response = _context.Estudios.Where(x => x.IdProf == idProf ).FirstOrDefault();
            return Task.FromResult(response);
        }

        public Task<IEnumerable<Estudio>> GetAll()
        {
            IEnumerable<Estudio> response = _context.Estudios.ToList();
            return Task.FromResult(response);

        }

        public void Post(Estudio _object)
        {
            throw new NotImplementedException();
        }

        public void Remove(Estudio _object)
        {
            throw new NotImplementedException();
        }

        public void Update(Estudio _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            return Task.FromResult("Si funciona estudioRepository");
        }
    }
}
