using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Models;
using Microsoft.AspNetCore.Mvc;
using BasicBilling.API.DataBase;
using BasicBilling.API.Service;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly ILogic _logic;
        public BillingController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpPost("bills")]
        public async Task<ActionResult<IEnumerable<Bill>>> PostBills([FromBody] Bill bill)
        {
            var BillsCreated = await _logic.CreateBilling(bill);
            if (BillsCreated.Count() == 0)
            {
                return NotFound();
            }
            return Ok(BillsCreated);
        }

        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetPending([FromQuery] long ClientId)
        {
            var PendingsByClientId = await _logic.GetPendingsByClientId(ClientId);
            if (PendingsByClientId == null)
            {
                return NotFound();
            }
            return Ok(PendingsByClientId);
        }

        [HttpPost("pay")]
        public async Task<ActionResult> PostPay([FromBody] Bill bill)
        {
            var Bill = await _logic.BillPayment(bill);
            if (Bill == null) return NotFound(bill);
            return Ok(Bill);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ClientBillDto>>> GetSearch([FromQuery] string category)
        {
            var PaymentHistory = await _logic.GetPaymentHistory(category);
            if (PaymentHistory == null)
            {
                return NotFound();
            }
            return Ok(PaymentHistory);
        }
        [HttpGet("clients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var Clients = await _logic.GetAllClients();
            if (Clients == null)
            {
                return NotFound();
            }
            return Ok(Clients);
        }
    }
}