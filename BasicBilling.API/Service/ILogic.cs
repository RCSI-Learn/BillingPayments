using System.Collections.Generic;
using System.Threading.Tasks;
using BasicBilling.API.Models;
namespace BasicBilling.API.Service
{
    public interface ILogic
    {
        Task<IEnumerable<Bill>> CreateBilling(Bill bill);
        Task<IEnumerable<Bill>> GetPendingsByClientId(long ClientId);
        Task<Bill> BillPayment(Bill bill);
        Task<IEnumerable<ClientBillDto>> GetPaymentHistory(string Category);
        Task<IEnumerable<Client>> GetAllClients();
    }
}