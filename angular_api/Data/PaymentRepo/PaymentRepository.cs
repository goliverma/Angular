using System.Collections.Generic;
using System.Threading.Tasks;
using angular_api.Data.IPaymentRepo;
using angular_models.Tabel;
using Microsoft.EntityFrameworkCore;

namespace angular_api.Data.PaymentRepo
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext context;

        public PaymentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Deletepayment(int id)
        {
            await Task.Run(async () => {
                var payment = await GetPayment(id);
                if(payment != null)
                {
                    context.PaymentDetails.Remove(payment);
                    await context.SaveChangesAsync();
                }
            });
        }

        public async Task<PaymentDetail> GetPayment(int id)
        {
            return await context.PaymentDetails.FindAsync(id); 
        }

        public async Task<IEnumerable<PaymentDetail>> GetsPayment()
        {
            return await context.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetail> PostPayment(PaymentDetail payment)
        {
            if(payment != null)
            {
                var result = await context.PaymentDetails.AddAsync(payment);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<PaymentDetail> UpdatePayment(PaymentDetail payment)
        {
            if(payment != null)
            {
                context.Entry(payment).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return payment;
            }
            return null;
        }
    }
}