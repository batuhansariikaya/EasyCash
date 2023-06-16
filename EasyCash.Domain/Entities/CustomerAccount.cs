using EasyCash.Domain.Entities.Common;
using EasyCash.Domain.Entities.Identity;
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
        public AppUser AppUser { get; set; }
        public List<CustomerAccountProcess> CustomerSender { get; set; }
        public List<CustomerAccountProcess> CustomerReceiver { get; set; }
    }
}
