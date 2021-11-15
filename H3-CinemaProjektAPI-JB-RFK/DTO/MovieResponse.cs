using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.DTO
{
    public class MovieResponse
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public DateTime Duration { get; set; }
        public DateTime MovieLength { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
