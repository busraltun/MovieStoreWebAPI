using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DataTransferObjects
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public DateTime MovieYear { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
    }
}
