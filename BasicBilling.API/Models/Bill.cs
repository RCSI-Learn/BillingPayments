using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Models
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }
        public long ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
    }
}