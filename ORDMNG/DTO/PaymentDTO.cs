using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public string Paymethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PayStamp { get; set; }
        public string TransactionId { get; set; }
        public int? Oid { get; set; }
        public int? ShipId { get; set; }
        public int? UserId { get; set; }
    }
}
