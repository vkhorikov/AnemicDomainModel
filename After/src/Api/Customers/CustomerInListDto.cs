using System;

namespace Api.Customers
{
    public class CustomerInListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public decimal MoneySpent { get; set; }
    }
}