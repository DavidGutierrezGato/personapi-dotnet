﻿using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IRepository<Persona>
    {
        private readonly persona_dbContext _context;

        public PersonaRepository(persona_dbContext context)
        {
            _context = context;
        }

        public Task<Persona> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persona>> GetAll()
        {
            IEnumerable<Persona> response = _context.Personas.ToList();
            return Task.FromResult(response);

        }

        public void Post(Persona _object)
        {
            throw new NotImplementedException();
        }

        public void Remove(Persona _object)
        {
            throw new NotImplementedException();
        }

        public void Update(Persona _object)
        {
            throw new NotImplementedException();
        }

        public Task<string> pruebaRepository()
        {
            return Task.FromResult("Si funciona personaRepository");
        }
    }
}
