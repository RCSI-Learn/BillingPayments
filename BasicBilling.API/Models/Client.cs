using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Models
{
    public class Client
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}