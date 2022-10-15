using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository : IRepository<Estudio>
    {
        public Task<Estudio> getEstudios(int idProf, int idPer);
    }
}
