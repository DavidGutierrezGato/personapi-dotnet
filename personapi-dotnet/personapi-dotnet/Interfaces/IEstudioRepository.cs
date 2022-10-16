using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository : IRepository<Estudio>
    {
        public Task<string> PostEstudios(EstudiosDTO _object);

        public Task<string> RemoveEstudios(int idProf, int idCC);

        public Task<Estudio> GetEstudios2ID(int idProf, int idCC);

        public Task<string> UpdateEstudios(EstudiosDTO _object);
    }
}
