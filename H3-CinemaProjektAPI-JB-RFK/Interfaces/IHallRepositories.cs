using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IHallRepositories
    {
        Task<Hall> GetHall(int Id);
        Task<List<Hall>> GetAllHalls();
        Task<Hall> DeleteHall(int Id);
        Task<Hall> CreateHall(Hall hall);
    }
}
