using System.Collections.Generic;
using System.Threading.Tasks;
using angular_models.Tabel;

namespace angular_api.Data.IPaymentRepo
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentDetail>> GetsPayment();
        Task<PaymentDetail> GetPayment(int id);
        Task<PaymentDetail> PostPayment(PaymentDetail payment);
        Task<PaymentDetail> UpdatePayment(PaymentDetail payment);
        Task Deletepayment(int id);
    }
}