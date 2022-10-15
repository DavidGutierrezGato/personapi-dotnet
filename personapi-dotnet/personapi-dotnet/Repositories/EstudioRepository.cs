using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
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

        public Task<string> Post(Estudio _object)
        {
            try
            {
                _context.Estudios.Add(_object);
                _context.SaveChanges();
                return Task.FromResult("Guardado");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> Remove(Estudio _object)
        {
            try
            {
                _context.Estudios.Remove(_object);
                _context.SaveChanges();
                return Task.FromResult("Removido");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> Update(Estudio _object)
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
            return Task.FromResult("Si funciona estudioRepository");
        }

        public Task<Estudio> getEstudios(int idProf, int idPer)
        {
            var response = _context.Estudios.Where(x => x.IdProf == idProf && x.CcPer == idPer).FirstOrDefault();
            return Task.FromResult(response);
        }
    }
}
