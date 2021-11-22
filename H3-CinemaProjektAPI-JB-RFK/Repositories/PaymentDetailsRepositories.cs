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

        #region create paymentdetails
        public async Task<PaymentDetails> CreatePayment(PaymentDetails paymentDetails)
        {
            context.PaymentDetails.Add(paymentDetails);
            await context.SaveChangesAsync();
            return paymentDetails;
        }
        #endregion

        #region update payment detail
        public async Task<PaymentDetails> UpdatePaymentDetails(int id, PaymentDetails data)
        {
            var findDetail = await context.PaymentDetails.Where(pd => pd.PaymentDetailsId == id).FirstOrDefaultAsync();
            if (findDetail != null)
            {
                findDetail.PaymentDetailsId = data.PaymentDetailsId;
                findDetail.PaymentMethod = data.PaymentMethod;
                findDetail.CardType = data.CardType;
                findDetail.TransactionId = data.TransactionId;
                findDetail.Paid = data.Paid;

                context.Entry(findDetail).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return findDetail;
            }
            return null;

        }
        #endregion

        #region delete payment detail (id)
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

        #region get all payment details
        public async Task<List<PaymentDetails>> GetAllPaymentDetails()
        {
            List<PaymentDetails> paymentList = await context.PaymentDetails.ToListAsync();
            return paymentList;
        }
        #endregion

        #region get payment detail (id)
        public async Task<PaymentDetails> GetPayment(int Id)
        {
            return await context.PaymentDetails.FindAsync(Id);
        }
        #endregion
    }
}
