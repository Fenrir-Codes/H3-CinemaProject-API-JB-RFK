using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IPaymentDeatailsRepositories
    {
        Task<PaymentDetails> GetPayment(int Id);
        Task<List<PaymentDetails>> GetAllPaymentDetails();

        Task<PaymentDetails> DeletePayment(int Id);
        Task<PaymentDetails> CreatePayment(PaymentDetails paymentDetails);
    }
}
