using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ProfileId { get; set; }
        public int MovieId { get; set; }
        public int PaymentId { get; set; }
        public int SeatNumberId { get; set; }
        public int HallId { get; set; }
        public bool DiscountCoupon { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
