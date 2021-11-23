using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int DirectorsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public DateTime Duration { get; set; }
        public DateTime ReleaseDate { get; set; }

        /* EF Relations */
        public ICollection<Booking> Bookings { get; set; }

    }
}
