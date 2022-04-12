using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DataTransferObjects
{
    public class MovieWithDirectorDto : MovieDto
    {
        public DirectorDto Director { get; set; }
    }
}
