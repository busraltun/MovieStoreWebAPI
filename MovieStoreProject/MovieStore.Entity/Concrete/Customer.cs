using MovieStore.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entity.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public ICollection<Genre> FavoriteGenres { get; set; }
        public ICollection<Movie> BuyMovies { get; set; }
    }
}
