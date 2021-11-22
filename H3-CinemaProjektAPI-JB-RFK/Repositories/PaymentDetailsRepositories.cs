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
    public class PaymentDetailsRepositories :IPaymentDeatailsRepositories
    {
        private readonly DataBaseContext context;

        public PaymentDetailsRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        #region Create/post payment
        public async Task<PaymentDetails> CreatePayment(PaymentDetails paymentDetails)
        {
            context.PaymentDetails.Add(paymentDetails);
            await context.SaveChangesAsync();
            return paymentDetails;
        }
        #endregion

        #region Delete payment
        public async Task<PaymentDetails> DeletePayment(int Id)
        {
            var payment = await context.PaymentDetails.FindAsync(Id);
            if (payment != null)
            {
                context.PaymentDetails.Remove(payment);
                await context.SaveChangesAsync();
            }
            return payment;
        }
        #endregion

        #region Get all payments
        public async Task<List<PaymentDetails>> GetAllPaymentDetails()
        {
            List<PaymentDetails> paymentList = await context.PaymentDetails.ToListAsync();
            return paymentList;
        }
        #endregion

        #region Get payment by id
        public async Task<PaymentDetails> GetPayment(int Id)
        {
            return await context.PaymentDetails.FindAsync(Id);
        }
        #endregion
    }
}
