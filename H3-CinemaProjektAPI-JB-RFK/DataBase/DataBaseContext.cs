using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace H3_CinemaProjektAPI_JB_RFK.DataBase
{
    public class DataBaseContext :DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :
           base(options)
        { }


        //Tables defined below --->
        public DbSet<Booking> Booking { get; set; } // property = table
        public DbSet<Directors> Directors { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<SeatNumber> SeatNumber { get; set; }


    }
}
