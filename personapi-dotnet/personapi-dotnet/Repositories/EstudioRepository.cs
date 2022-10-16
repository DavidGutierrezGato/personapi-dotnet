using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly persona_dbContext _context;

        public EstudioRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Task<Estudio> Get(int idProf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estudio>> GetAll()
        {
            IEnumerable<Estudio> response = _context.Estudios.ToList();
            return Task.FromResult(response);

        }

        public Task<string> Post(Estudio _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> Remove(Estudio _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(Estudio _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            return Task.FromResult("Si funciona estudioRepository");
        }

        public Task<Estudio> getEstudios(int idProf, int idPer)
        {
            throw new NotImplementedException();
        }




        public Task<string> PostEstudios(EstudiosDTO _object)
        {
            try
            {
                Estudio estudio = new Estudio();
                estudio.IdProf = _object.IdProf;
                estudio.CcPer = _object.CcPer;
                estudio.Fecha = _object.Fecha;
                estudio.Univer = _object.Univer;

                var persona = _context.Personas.FirstOrDefault(x => x.Cc == estudio.CcPer);

                var profesion = _context.Profesions.FirstOrDefault(x => x.Id == estudio.IdProf);

                if (persona != null && profesion != null)
                {
                    estudio.CcPerNavigation = persona;
                    estudio.IdProfNavigation = profesion;

                    _context.Estudios.Add(estudio);
                    _context.SaveChanges();
                    return Task.FromResult("Guardado");
                }
                else
                {
                    return Task.FromResult("sin dueño");
                }

            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> RemoveEstudios(int idProf, int idCC)
        {
            try
            {
                var estudio = _context.Estudios.FirstOrDefault(x => x.CcPer == idCC && x.IdProf == idProf);
                if (estudio != null)
                {
                    _context.Estudios.Remove(estudio);
                    _context.SaveChanges();
                    return Task.FromResult("Removido");
                }

                return Task.FromResult("Error");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> UpdateEstudios(EstudiosDTO _object)
        {
            try
            {
                var estudio = _context.Estudios.FirstOrDefault(x => x.CcPer == _object.CcPer && x.IdProf == _object.IdProf);
                if (estudio != null)
                {
                    estudio.IdProf = _object.IdProf;
                    estudio.CcPer = _object.CcPer;
                    estudio.Fecha = _object.Fecha;
                    estudio.Univer = _object.Univer;

                    _context.Entry(estudio).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Task.FromResult("Actualizado");
                }

                return Task.FromResult("Error");
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<Estudio> GetEstudios2ID(int idProf, int idCC)
        {
            var response = _context.Estudios.Where(x => x.IdProf == idProf && x.CcPer == idCC).FirstOrDefault();
            return Task.FromResult(response);
        }
    }
}
