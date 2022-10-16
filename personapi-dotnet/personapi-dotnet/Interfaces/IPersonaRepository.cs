using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        public Task<string> PostPersona(PersonaDTO _object);

        public Task<string> RemovePersona(int cc);

        public Task<string> UpdatePersona(PersonaDTO _object);
    }
}
