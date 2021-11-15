using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.DTO
{
    public class SeatNumberResponse
    {
        public int SeatNumberId { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }
    }
}
