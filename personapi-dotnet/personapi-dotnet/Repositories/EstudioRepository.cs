using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IRepository<Estudio>
    {
        public Estudio Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estudio> GetAll()
        {
            throw new NotImplementedException();
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
