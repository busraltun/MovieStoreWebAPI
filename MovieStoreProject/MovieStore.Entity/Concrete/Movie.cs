using MovieStore.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entity.Concrete
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public DateTime MovieYear { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }  
        public ICollection<MovieActor> Actors { get; set; }  
    }
}
