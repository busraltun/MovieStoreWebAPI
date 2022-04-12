using MovieStore.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entity.Concrete
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
    }
}
