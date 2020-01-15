using System;
using Entities.DTOs;
using Entities.Entities;

namespace Entities.Mappers
{
    public class CountryMapper
    {
        public CountryMapper()
        {
        }

        public CountryDTO MapCountryToCountryDTO(Country country)
        {
            CountryDTO countryDTO = new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
                LanguageId = country.Language.Id,
                LanguageName = country?.Language?.Name
                
            };

            return countryDTO;
        }


    }
}
