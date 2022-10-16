using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IProfesionRepository : IRepository<Profesion>
    {
        public Task<string> PostProfesion(ProfesionDTO _object);

        public Task<string> RemoveProfesion(int numero);

        public Task<string> UpdateProfesion(ProfesionDTO _object);
    }
}
