using System;

namespace Entities.Entities
{
    public class Stream
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Country Country { get; set; }


    }
}
