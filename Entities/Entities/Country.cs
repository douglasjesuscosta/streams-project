using System;
namespace Entities.Entities
{
    public class Country
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public Language Language { get; set; }
    }
}
