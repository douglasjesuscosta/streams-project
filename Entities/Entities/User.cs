using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Stream> Streammers { get; set; }

        public User()
        {

        }
    }
}
