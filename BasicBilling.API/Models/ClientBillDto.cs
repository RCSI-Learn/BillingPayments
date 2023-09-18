namespace BasicBilling.API.Models
{
    public class ClientBillDto
    {
        public string ClientName { get; set; }
        public int Period { get; set; }
        public string Category { get; set; }
        public string State { get; set; }
    }
}