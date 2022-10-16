using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.DTOs;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {


        private readonly persona_dbContext _context;

        public TelefonoRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Task<Telefono> Get(int id)
        {
            var response = _context.Telefonos.Where(x => x.Num == id).FirstOrDefault();
            return Task.FromResult(response);
        }

        public Task<IEnumerable<Telefono>> GetAll()
        {
            IEnumerable<Telefono> response = _context.Telefonos.ToList();
            return Task.FromResult(response);
        }

        public Task<string> PostTelefono(TelefonoDTO _object)
        {
            try
            {
                Telefono telefono = new Telefono();
                telefono.Num = _object.Num;
                telefono.Duenio = _object.Duenio;
                telefono.Oper = _object.Oper;

                var persona = _context.Personas.FirstOrDefault(x => x.Cc == telefono.Duenio);

                if(persona != null)
                {
                    telefono.DuenioNavigation = persona;
                    _context.Telefonos.Add(telefono);
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

        public Task<string> Post(Telefono _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveTelefono(int numero)
        {
            try
            {
                var telefono = _context.Telefonos.FirstOrDefault(x => x.Num == numero);
                if(telefono != null)
                {
                    _context.Telefonos.Remove(telefono);
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

        public Task<string> Remove(Telefono _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTelefono(TelefonoDTO _object)
        {
            try
            {
                var telefono = _context.Telefonos.FirstOrDefault(x => x.Num == _object.Num);
                //_context.Telefonos.Update(telefono);

                if (telefono != null)
                {
                    telefono.Duenio = _object.Duenio;
                    telefono.Num = _object.Num;
                    telefono.Oper = _object.Oper;

                    _context.Entry(telefono).State = EntityState.Modified;
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

        public Task<string> Update(Telefono _object)
        {
            throw new NotImplementedException();
        }
    }
}
