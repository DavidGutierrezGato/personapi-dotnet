using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> Get(int id);

        public Task<string> Post(T _object);

        public Task<string> Remove(T _object);

        public Task<string> Update(T _object);

        public Task<string> pruebaRepository();
    }
}
