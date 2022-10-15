using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : IRepository<Telefono>
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

        public void Post(Telefono _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            throw new NotImplementedException();
        }

        public void Remove(Telefono _object)
        {
            throw new NotImplementedException();
        }

        public void Update(Telefono _object)
        {
            throw new NotImplementedException();
        }
    }
}
