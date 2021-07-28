using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    class CustomerStatus : ValueObject<CustomerStatus>
    {
        public static readonly CustomerStatus Regular = new CustomerStatus(CustomerStatusType.Regular, ExpirationDate.Infinite);
        public CustomerStatusType Type { get; }
        private readonly DateTime? _expirationDate;
        public ExpirationDate StatusExpirationDate => (ExpirationDate)_expirationDate;

        private CustomerStatus(CustomerStatusType type, ExpirationDate expirationDate)
        {
            Type = type;
            _expirationDate = expirationDate;
        }
        public bool IsAdvanced => Type == CustomerStatusType.Advanced && !ExpirationDate.IsExpired;
        protected override bool EqualsCore(CustomerStatus other)
        {
            return Type == other.Type && ExpirationDate == other.ExpirationDate;
        }

        public CustomerStatus Promote()
        {
            return new CustomerStatus(CustomerStatusType.Advanced, (ExpirationDate)DateTime.UtcNow.AddYears(1));
        }

        protected override int GetHashCodeCore()
        {
            return Type.GetHashCode() ^ ExpirationDate.GetHashCode();
        }
    }
    public enum CustomerStatusType
    {
        Regular = 1,
        Advanced = 2
    }
}
