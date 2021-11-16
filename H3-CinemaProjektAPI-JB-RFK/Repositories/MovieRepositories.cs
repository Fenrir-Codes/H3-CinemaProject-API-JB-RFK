using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Repositories
{
    public class MovieRepositories : IMovieRepositories
    {
        private readonly DataBaseContext context;

        public MovieRepositories(DataBaseContext _context)
        {
            context = _context;
        }
    }
}
