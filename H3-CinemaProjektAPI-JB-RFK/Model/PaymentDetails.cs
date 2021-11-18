﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Model
{
    public class PaymentDetails
    {
        public int PaymentDetailsId { get; set; }
        public int TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public string CardType { get; set; }
        public bool Paid { get; set; }

        //NOT used ,shoudn't store cardnumber in database
        //public int CardNumber { get; set; }
    }
}
