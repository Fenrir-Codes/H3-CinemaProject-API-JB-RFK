﻿using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class PaymentDetailsService : IPaymentDetailsService
    {
        private readonly IPaymentDeatailsRepositories context;

        public PaymentDetailsService(IPaymentDeatailsRepositories _context)
        {
            context = _context;
        }

        public async Task<List<PaymentDetails>> GetAllPaymentDetails()
        {
            return await context.GetAllPaymentDetails();
        }

        public async Task<PaymentDetails> GetPayment(int Id)
        {
            return await context.GetPayment(Id);
        }
    }
}
