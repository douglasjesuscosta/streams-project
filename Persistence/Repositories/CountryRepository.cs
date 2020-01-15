using System.Threading.Tasks;
using System.Collections.Generic;

using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    /**
     * Classe CountryRepository
     *
     * Classe que tem como funcao isolar a logica
     * de comunicacao com o banco de dados e realiza
     * cao de consultas e persistencia.
     * */
    public class CountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /**
         * Obtencao de todos os paises
         * */
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _dataContext.Countries
                                     .Include(country => country.Language) 
                                     .ToListAsync();

        }

    }
}
