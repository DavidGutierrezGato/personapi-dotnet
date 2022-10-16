using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {

        private readonly persona_dbContext _context;

        public ProfesionRepository(persona_dbContext context)
        {
            _context = context;
        }


        public Task<Profesion> Get(int id)
        {
            var response = _context.Profesions.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(response);
        }

        public Task<IEnumerable<Profesion>> GetAll()
        {
            IEnumerable<Profesion> response = _context.Profesions.ToList();
            return Task.FromResult(response);

        }

        public Task<string> Post(Profesion _object)
        {
            throw new NotImplementedException();
        }

        

        public Task<string> pruebaRepository()
        {
            throw new NotImplementedException();
        }

        public Task<string> Remove(Profesion _object)
        {
            throw new NotImplementedException();
        }

        

        public Task<string> Update(Profesion _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateProfesion(ProfesionDTO _object)
        {
            try
            {
                var profesion = _context.Profesions.FirstOrDefault(x => x.Id == _object.Id);
                //_context.Telefonos.Update(telefono);

                if (profesion != null)
                {
                    profesion.Id = _object.Id;
                    profesion.Nom = _object.Nom;
                    profesion.Des = _object.Des;

                    _context.Entry(profesion).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Task.FromResult("Actualizado");
                }
                else
                {
                    return Task.FromResult("Error");
                }
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }

        public Task<string> PostProfesion(ProfesionDTO _object)
        {

            try
            {
                Profesion profesion = new Profesion();
                profesion.Id = _object.Id;
                profesion.Des = _object.Des;
                profesion.Nom = _object.Nom;

                profesion.Estudios = null;

                _context.Profesions.Add(profesion);
                _context.SaveChanges();
                return Task.FromResult("Guardado");
            }
            catch
            {
                return Task.FromResult("error");
            }


        }

        public Task<string> RemoveProfesion(int numero)
        {
            try
            {
                var profesion = _context.Profesions.FirstOrDefault(x => x.Id == numero);
                if (profesion != null)
                {
                    _context.Profesions.Remove(profesion);
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
    }
}
