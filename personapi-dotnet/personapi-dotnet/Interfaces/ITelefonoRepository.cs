using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface ITelefonoRepository : IRepository<Telefono>
    {
        public Task<string> PostTelefono(TelefonoDTO _object);

        public Task<string> RemoveTelefono(int numero);

        public Task<string> UpdateTelefono(TelefonoDTO _object);
    }
}
