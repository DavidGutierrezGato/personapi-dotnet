using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {

        private readonly persona_dbContext _context;

        public ProfesionRepository(persona_dbContext context)
        {
            _context = context;
        }


        public Task<Profesion> Get(int id)
        {
            var response = _context.Profesions.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(response);
        }

        public Task<IEnumerable<Profesion>> GetAll()
        {
            IEnumerable<Profesion> response = _context.Profesions.ToList();
            return Task.FromResult(response);

        }

        public Task<string> Post(Profesion _object)
        {
            try
            {
                _context.Profesions.Add(_object);
                _context.SaveChanges();
                return Task.FromResult("Guardado");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> pruebaRepository()
        {
            throw new NotImplementedException();
        }

        public Task<string> Remove(Profesion _object)
        {
            try
            {
                _context.Profesions.Remove(_object);
                _context.SaveChanges();
                return Task.FromResult("Removido");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> Update(Profesion _object)
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
    }
}
