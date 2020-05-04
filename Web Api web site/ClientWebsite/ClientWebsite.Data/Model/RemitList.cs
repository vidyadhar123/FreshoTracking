using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebsite.Data.Model
{
    public class RemitList
    {
        public int Id { get; set; }
        public string balanceDue { get; set; }
        public string paymentDate { get; set;}
        public string checkNumber { get; set; }
        public string refInvoiceAmount { get; set; }
        public string refOrderNumber { get; set; }
        public string itemBalanceDue { get; set; }
        public string refInvoiceNumber { get; set; }
        public string refInvoiceDate { get; set; }
        public string refInvoiceDiscAmount { get; set; }
        public string refInvoiceAdjNumber { get; set; }
    }
}
