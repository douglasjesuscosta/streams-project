using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /**
     * Classe StreamRepository
     *
     * Classe que tem como funcao isolar a logica
     * de comunicacao com o banco de dados e realiza
     * cao de consultas e persistencia.
     * */
    public class StreamRepository
    {
        private readonly DataContext _dataContext;

        public StreamRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        /**
         * Obtencao de todas as streammers
         * */
        public async Task<IEnumerable<Stream>> GetAllStreammers()
        {
            return await _dataContext.Streams
                    .Include(stream => stream.Country.Language)
                    .ToListAsync();
                                   
        }

        /**
         * Obtencao de uma streammer por Id
         *
         * @param Id
         * */
        public async Task<Stream> GetStream(int Id)
        {
            return await _dataContext.Streams.FindAsync(Id);
        }

        /**
         * Adicao de streammer
         * */
        public async Task<Boolean> AddStream(Stream stream)
        {
            Country country = stream.Country;

            _dataContext.Attach(country);
            _ = _dataContext.Streams.AddAsync(stream);
           return await _dataContext.SaveChangesAsync() > 0;
        }

        /**
         * Atualizacao de streammer
         */
        public async Task<Boolean> UpdateStream(Stream stream)
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        /**
         * Exclusao de streammer
         */
         public async Task<Boolean> DeleteStream(Stream stream)
        {
            _dataContext.Streams.Remove(stream);
            return await _dataContext.SaveChangesAsync() > 0;
        }

    }
}
