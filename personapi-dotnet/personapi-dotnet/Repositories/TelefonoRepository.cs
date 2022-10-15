using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {


        private readonly persona_dbContext _context;

        public TelefonoRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Task<Telefono> Get(int id)
        {
            var response = _context.Telefonos.Where(x => x.Num == id.ToString()).FirstOrDefault();
            return Task.FromResult(response);
        }

        public Task<IEnumerable<Telefono>> GetAll()
        {
            IEnumerable<Telefono> response = _context.Telefonos.ToList();
            return Task.FromResult(response);
        }

        public Task<string> Post(Telefono _object)
        {
            try
            {
                _context.Telefonos.Add(_object);
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

        public Task<string> Remove(Telefono _object)
        {
            try
            {
                _context.Telefonos.Remove(_object);
                _context.SaveChanges();
                return Task.FromResult("Removido");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> Update(Telefono _object)
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
