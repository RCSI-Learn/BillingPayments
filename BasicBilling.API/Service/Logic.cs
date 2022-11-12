using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Models;
using BasicBilling.API.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Service
{
    public class Logic
    {
        private readonly DataContext _context;
        public Logic(DataContext context){
            _context = context;
        }
        public async Task<List<Bill>> CreateBilling(Bill bill) {
            var NewBills = new List<Bill>();
            if (bill.Period < 2022 || string.IsNullOrWhiteSpace(bill.Category)) return NewBills; //invalid period
            bill.Category = bill.Category.Trim().ToUpper();

            await _context.Clients.ForEachAsync(x => NewBills.Add(
                new Bill{
                    Id = Guid.NewGuid(),
                    ClientId = x.Id,
                    Period = bill.Period,
                    Category = bill.Category,
                    State = "PENDING"
                }
            ));
            // this section removes all the new bills that already exist, preventing duplicate payment for clients.
            await _context.Bills.ForEachAsync(x => {
                NewBills.RemoveAll(y => x.ClientId == y.ClientId && x.Period == y.Period && x.Category == y.Category);
            });
            // if exist, add  Client(s) that dont have the bill for the period and category
            if (NewBills.Count > 0){
                await _context.Bills.AddRangeAsync(NewBills);
                await _context.SaveChangesAsync();
            }
            return NewBills;
        }
        public async Task<List<Bill>> GetPendingsByClientId(long ClientId) {
            return await _context.Bills.Where(x => x.ClientId == ClientId && x.State == "PENDING").ToListAsync();
        }
        public async Task<Bill> BillPayment(Bill bill) {
            var Search_Bill = await _context.Bills.FirstOrDefaultAsync( x => x.ClientId == bill.ClientId && x.Period == bill.Period && x.Category == bill.Category && x.State == "PENDING");
            if (Search_Bill == null) return null;

            Search_Bill.State = "PAID";
            await _context.SaveChangesAsync();

            return Search_Bill;
        }

        public async Task<List<Bill>> GetPaymentHistory(string Category) {
            return await _context.Bills.Where(x => x.Category == Category && x.State == "PAID").ToListAsync();
        }
    }
}