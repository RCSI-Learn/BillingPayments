using System;

public class Bill{
        public Guid Id { get; set; }
        public long ClientId{ get; set; }
        public string Period { get; set; }
        public string MonthYear { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
    }