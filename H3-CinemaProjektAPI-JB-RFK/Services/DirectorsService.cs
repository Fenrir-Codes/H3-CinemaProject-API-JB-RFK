﻿using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class DirectorsService : IDirectorsService
    {
        private readonly IDirectorsRepositories context;

        public DirectorsService(IDirectorsRepositories _context)
        {
            context = _context;
        }

        public async Task<Directors> ByLastName(string lastName)
        {
            return await context.ByLastName(lastName);
        }

        public async Task<Directors> ByFirstName(string name)
        {
            return await context.ByFirstName(name);
        }

        public async Task<Directors> CreateDirector(Directors directors)
        {
            return await context.CreateDirector(directors);
        }

        public async Task<bool> DeleteDirector(int Id)
        {
            var temp = await context.DeleteDirector(Id);
            return temp != null;
        }

        public async Task<List<Directors>> GetAllDirectors()
        {
            return await context.GetAllDirectors();
        }

        public async Task<Directors> GetDirector(int Id)
        {
            return await context.GetDirector(Id);
        }
    }
}
