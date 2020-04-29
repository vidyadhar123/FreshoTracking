using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebsite.Data.Model
{
    public class RemitList
    {
        public int Id { get; set; }
        public double balanceDue { get; set; }
        public string paymentDate { get; set;}
        public long checkNumber { get; set; }
        public int refInvoiceAmount { get; set; }
        public long refOrderNumber { get; set; }
        public double itemBalanceDue { get; set; }
        public long refInvoiceNumber { get; set; }
        public string refInvoiceDate { get; set; }
        public double refInvoiceDiscAmount { get; set; }
        public long refInvoiceAdjNumber { get; set; }
    }
}
