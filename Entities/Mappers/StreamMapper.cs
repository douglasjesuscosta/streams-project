using System;
using Entities.DTOs;
using Entities.Entities;

namespace Entities.Mappers
{
    public class StreamMapper
    {
        public StreamMapper()
        {}

        public StreamDTO MapStreamToStreamDTO(Stream stream)
        {
            StreamDTO streamDTO = new StreamDTO
            {
                Id = stream.Id,
                Name = stream.Name,
                Description = stream.Description,
                IdCountry = stream.CountryId,
                CountryName = stream.Country.Name,
                IdLanguage = stream.Country.Language.Id,
                LanguageName = stream.Country.Language.Name
            };

            return streamDTO;
        }

        public Stream MapStreamDTOToStream(StreamDTO streamDTO)
        {
            Stream stream = new Stream
            {
                Id = streamDTO.Id,
                Name = streamDTO.Name,
                Description = streamDTO.Description,
                CountryId = (int) streamDTO.IdCountry
            };

            return stream;
        }
    }
}
