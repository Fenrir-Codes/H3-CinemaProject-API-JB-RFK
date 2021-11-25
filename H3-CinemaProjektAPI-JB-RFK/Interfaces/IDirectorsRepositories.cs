using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IDirectorsRepositories
    {
        Task<Directors> GetDirector(int Id);

        Task<List<Directors>> GetAllDirectors();

        Task<Directors> DeleteDirector(int Id);

        Task<Directors> CreateDirector(Directors directors);

        Task<Directors> UpdateDirector(int id, Directors data);

        Task<Directors> ByFirstName(string firstName);

        Task<Directors> ByLastName(string lastName);
    }
}
