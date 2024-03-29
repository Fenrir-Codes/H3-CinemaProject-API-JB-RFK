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

        #region Get director by lastname
        public async Task<Directors> ByLastName(string lastName)
        {
            return await context.ByLastName(lastName);
        }
        #endregion

        #region Get director by first name
        public async Task<Directors> ByFirstName(string name)
        {
            return await context.ByFirstName(name);
        }
        #endregion

        #region create director
        public async Task<Directors> CreateDirector(Directors directors)
        {
            return await context.CreateDirector(directors);
        }
        #endregion

        #region update director
        public async Task<Directors> UpdateDirector(int id, Directors data)
        {
            return await context.UpdateDirector(id, data);
        }
        #endregion

        #region delete director (id)
        public async Task<bool> DeleteDirector(int Id)
        {
            var temp = await context.DeleteDirector(Id);
            return temp != null;
        }
        #endregion

        #region get all directors
        public async Task<List<Directors>> GetAllDirectors()
        {
            return await context.GetAllDirectors();
        }
        #endregion

        #region get director (id)
        public async Task<Directors> GetDirector(int Id)
        {
            return await context.GetDirector(Id);
        }
        #endregion

        #region Movie by dirctor
        public async Task<List<Directors>> MovieByDirector(string fname, string lname)
        {
            return await context.MovieByDirector(fname, lname);
        }
        #endregion
    }
}
