using H3_CinemaProjektAPI_JB_RFK.Interfaces;
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


        #region create payment details
        public async Task<PaymentDetails> CreatePayment(PaymentDetails paymentDetails)
        {
            return await context.CreatePayment(paymentDetails);
        }
        #endregion

        #region update details
        public async Task<PaymentDetails> UpdatePaymentDetails(int id, PaymentDetails data)
        {
            return await context.UpdatePaymentDetails(id, data);
        }
        #endregion

        #region deleta payment detail (id)
        public async Task<bool> DeletePayment(int Id)
        {
            var temp = await context.DeletePayment(Id);
            return temp != null;
        }
        #endregion

        #region get all details
        public async Task<List<PaymentDetails>> GetAllPaymentDetails()
        {
            return await context.GetAllPaymentDetails();
        }
        #endregion

        #region get detail (id)
        public async Task<PaymentDetails> GetPayment(int Id)
        {
            return await context.GetPayment(Id);
        }
        #endregion
    }
}
