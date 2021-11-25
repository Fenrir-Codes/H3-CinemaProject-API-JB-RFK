using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Repositories
{
    public class DirectorsRepositories : IDirectorsRepositories
    {
        private readonly DataBaseContext context;

        public DirectorsRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        #region Get director by lastname
        public async Task<Directors> ByLastName(string lastName)
        {
            return await context.Directors.Where(n => n.LastName == lastName).FirstOrDefaultAsync();
        }
        #endregion

        #region Get director by first name
        public async Task<Directors> ByFirstName(string firstName)
        {
            return await context.Directors.Where(fname => fname.FirstName == firstName).FirstOrDefaultAsync();
        }
        #endregion

        #region create director
        public async Task<Directors> CreateDirector(Directors directors)
        {
            context.Directors.Add(directors);
            await context.SaveChangesAsync();
            return directors;
        }
        #endregion

        #region update director
        public async Task<Directors> UpdateDirector(int id, Directors data)
        {
            var findDirector = await context.Directors.Where(d => d.DirectorsId == id).FirstOrDefaultAsync();
            if (findDirector != null)
            {
                findDirector.DirectorsId = data.DirectorsId;
                findDirector.FirstName = data.FirstName;
                findDirector.LastName = data.LastName;

                context.Entry(findDirector).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return findDirector;
            }
            return null;

        }
        #endregion

        #region delete director (id)
        public async Task<Directors> DeleteDirector(int Id)
        {
            var director = context.Directors.Find(Id);
            if (director != null)
            {
                context.Directors.Remove(director);
                await context.SaveChangesAsync();
            }
            return director;
        }
        #endregion

        #region get all directors
        public async Task<List<Directors>> GetAllDirectors()
        {
            List<Directors> directorList = await context.Directors.ToListAsync();
            return directorList;
        }
        #endregion

        #region get director (id)
        public async Task<Directors> GetDirector(int Id)
        {
            return await context.Directors.FindAsync(Id);
        }
        #endregion

        //#region Movie by director
        //public async Task<List<Directors>> MovieByDirector(Movie movie)
        //{
        //    var movie = await context.Directors.Where(name => name.Movies == Movie)
        //    return movie;
        //}
        //#endregion
    }
}
