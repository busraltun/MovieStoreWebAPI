using MovieStore.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entity.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string BuyMovie { get; set; }
        public DateTime BuyDate { get; set; }

    }
}
