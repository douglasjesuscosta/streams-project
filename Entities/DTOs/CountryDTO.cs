using System;
namespace Entities.DTOs
{
    public class CountryDTO
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string LanguageName { get; set; }
        public int LanguageId { get; set; }

        public CountryDTO()
        {
        }
    }
}
