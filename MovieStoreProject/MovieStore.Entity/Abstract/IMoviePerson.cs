using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entity.Abstract
{
    public interface IMoviePerson
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
