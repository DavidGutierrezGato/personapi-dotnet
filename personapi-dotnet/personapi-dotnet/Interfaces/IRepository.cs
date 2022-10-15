namespace personapi_dotnet.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T Get(int id);

        public void Post(T _object);

        public void Remove(T _object);

        public void Update(T _object);

        public Task<string> pruebaRepository();
    }
}
