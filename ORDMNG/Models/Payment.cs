using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string Paymethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PayStamp { get; set; }
        public string TransactionId { get; set; }
        public int? Oid { get; set; }
        public int? ShipId { get; set; }
        public int? UserId { get; set; }

        public Orders O { get; set; }
        public Shipping Ship { get; set; }
        public Users User { get; set; }
    }
}
