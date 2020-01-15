using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Entities.DTOs;
using Persistence.Repositories;
using Entities.Entities;
using System.Linq;
using Entities.Mappers;

namespace UseCases.Contries
{
    public class List
    {
        public class Query : IRequest<List<CountryDTO>>
        {}

        public class Handler : IRequestHandler<Query, List<CountryDTO>>
        {
            private readonly CountryRepository _coutryRepository;
            private readonly CountryMapper _countryMapper;

            public Handler(CountryRepository coutryRepository, CountryMapper countryMapper)
            {
                _coutryRepository = coutryRepository;
                _countryMapper = countryMapper;
            }

            public async Task<List<CountryDTO>> Handle(Query request, CancellationToken cancellationToken)
            {

                var countries = await _coutryRepository.GetAllCountries();
                return this.ConvertCountriesToCointriesDTO(countries.ToList());
            }

            private List<CountryDTO> ConvertCountriesToCointriesDTO(List<Country> countries)
            {
                return countries.Select(country => _countryMapper.MapCountryToCountryDTO(country)).ToList();
            }
            
        }
    }
}
