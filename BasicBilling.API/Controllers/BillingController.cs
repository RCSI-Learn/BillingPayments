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
        
        private readonly Logic _logic;
        public BillingController(DataContext context){
            _logic = new Logic(context);
        }

        [HttpPost("bills")]
        public async Task<ActionResult<List<Bill>>> PostBills([FromBody] Bill bill)
        {
            return await _logic.CreateBilling(bill);
        }

        [HttpGet("pending")]
        public async Task<ActionResult<List<Bill>>> GetPending([FromQuery]long ClientId)
        {
            return await _logic.GetPendingsByClientId(ClientId);
        }

        [HttpPost("pay")]
        public async Task<IActionResult> PostPay([FromBody] Bill bill)
        {
            var Bill = await _logic.BillPayment(bill);
            if(Bill == null) return NotFound(bill);
            return Ok(Bill);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Bill>>> GetSearch([FromQuery]string category)
        {
            return await _logic.GetPaymentHistory(category);
        }
    }
}