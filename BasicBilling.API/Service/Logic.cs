using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Models;
using BasicBilling.API.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Service
{
    public class Logic : ILogic
    {
        private readonly DataContext _context;
        public Logic(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Bill>> CreateBilling(Bill bill)
        {
            Bill[] NewBills = new Bill[0];
            if (bill.Period < DateTime.Now.Year || string.IsNullOrWhiteSpace(bill.Category)) return NewBills; //invalid period
            bill.Category = bill.Category.Trim().ToUpper();

            //Create Bills for every client
            NewBills = _context.Clients.Select(x => new Bill
            {
                Id = Guid.NewGuid(),
                ClientId = x.Id,
                Period = bill.Period,
                Category = bill.Category,
                State = "PENDING"
            }).ToArray();

            // this section removes all the new bills that already exist, preventing duplicate payment for clients. 
            NewBills = NewBills.Where(newBill =>
                !_context.Bills.Any(Bill =>
                Bill.ClientId == newBill.ClientId &&
                Bill.Period == newBill.Period &&
                Bill.Category == newBill.Category
            )).ToArray();

            // if exist, add  Client(s) that dont have the bill for the period and category
            if (NewBills.Count() > 0)
            {
                await _context.Bills.AddRangeAsync(NewBills);
                await _context.SaveChangesAsync();
            }
            return NewBills;
        }
        public async Task<IEnumerable<Bill>> GetPendingsByClientId(long ClientId)
        {
            return await _context.Bills.Where(x => x.ClientId == ClientId && x.State == "PENDING").ToArrayAsync();
        }
        public async Task<Bill> BillPayment(Bill bill)
        {
            var Search_Bill = await _context.Bills.FirstOrDefaultAsync(x => x.ClientId == bill.ClientId && x.Period == bill.Period && x.Category == bill.Category && x.State == "PENDING");
            if (Search_Bill == null) return null;

            Search_Bill.State = "PAID";
            await _context.SaveChangesAsync();

            return Search_Bill;
        }
        public async Task<IEnumerable<ClientBillDto>> GetPaymentHistory(string Category)
        {
            var BillsByCategory = await _context.Bills.Where(x => x.Category == Category && x.State == "PAID").ToArrayAsync();
            var ClientBillDtos = BillsByCategory.Select(bill => new ClientBillDto {
                        ClientName = _context.Clients.Where(x => x.Id == bill.ClientId).First().Name,
                        Period = bill.Period,
                        Category = bill.Category,
                        State = bill.State
                    }).ToArray();
            return ClientBillDtos;
        }
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients.ToArrayAsync();
        }
    }
}