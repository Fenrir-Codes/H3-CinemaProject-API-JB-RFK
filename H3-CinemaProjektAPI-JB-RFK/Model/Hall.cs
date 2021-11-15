using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Model
{
    public class Hall
    {
        public int HallId { get; set; }
        public int SeatNumberId { get; set; }
        public string HallGreat { get; set; }
        public string HallSmall { get; set; }

        /* EF Relations */
        public ICollection<SeatNumber> SeatNumbers { get; set; }

    }
}
