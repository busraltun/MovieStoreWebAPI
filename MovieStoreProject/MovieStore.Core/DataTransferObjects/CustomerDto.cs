using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DataTransferObjects
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
