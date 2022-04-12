﻿using MovieStore.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entity.Concrete
{
    public class Director : IEntity, IMoviePerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
