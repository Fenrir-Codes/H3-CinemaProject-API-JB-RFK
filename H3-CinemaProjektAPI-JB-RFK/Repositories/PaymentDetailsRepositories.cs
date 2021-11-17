﻿using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Repositories
{
    public class PaymentDetailsRepositories :IPaymentDeatailsRepositories
    {
        private readonly DataBaseContext context;

        public PaymentDetailsRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        public async Task<List<PaymentDetails>> GetAllPaymentDetails()
        {
            List<PaymentDetails> paymentList = await context.PaymentDetails.ToListAsync();
            return paymentList;
        }

        public async Task<PaymentDetails> GetPayment(int Id)
        {
            return await context.PaymentDetails.FindAsync(Id);
        }
    }
}
