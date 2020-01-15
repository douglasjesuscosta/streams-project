using System;
namespace Entities.DTOs
{
    public class StreamDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public int? IdCountry { get; set; }

        public string CountryName { get; set; }

        public int? IdLanguage { get; set; }

        public string LanguageName { get; set; }

        public string IdUser { get; set; }

    }
}
