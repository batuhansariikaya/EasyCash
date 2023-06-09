using EasyCash.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Domain.Entities
{
    public class CustomerAccountProcess:BaseEntity
    {
        public string ProcessType { get; set; }
        public decimal Amount{ get; set; }
        public DateTime ProcessDate{ get; set; }
    }
}
