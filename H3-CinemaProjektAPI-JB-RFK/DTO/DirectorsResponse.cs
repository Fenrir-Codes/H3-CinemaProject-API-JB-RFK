﻿using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.DTO
{
    /// <summary>
    /// (D)ata(T)ransfer(O)bject
    /// </summary>

    public class DirectorsResponse
    {
        public int DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Movie> Movie { get; set; }

    }
}
