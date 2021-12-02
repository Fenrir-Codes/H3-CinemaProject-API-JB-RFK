using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.DTO
{
    public class MovieByDirectorResponse
    {
        //public string Title { get; set; }
        //public string Language { get; set; }
        //public string Country { get; set; }
        //public string Genre { get; set; }
        //public string Image { get; set; }
        //public DateTime ReleaseDate { get; set; }

        public List<Movie> Movie { get; set; }
        //public List<Directors> Directors { get; set; }

        //public int DirectorId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
    }
}
