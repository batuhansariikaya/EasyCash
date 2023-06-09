using EasyCash.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Domain.Entities
{
    public class CustomerAccount:BaseEntity
    {
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance  { get; set; }
        public string BankBranch  { get; set; }
    }
}
