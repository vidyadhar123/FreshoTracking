using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebsite.ViewModel
{
    public class GetUserDetailsModel
    {
        public string CustomerName { get; set; }
        public string OrderSource { get; set; }
        public string TxnId { get; set; }
        public string Date { get; set; }
        public double Total { get; set; }
        public double Fee { get; set; }
        public string ShipDate { get; set; }
        public string Carrier { get; set; }
        public string Method { get; set; }
        public double Weight { get; set; }
        public string Tracking { get; set; }
        public double Postage { get; set; }
        public string Items { get; set; }
        public int Qtys { get; set; }
        public string Skus { get; set; }
        public double Subtotals { get; set; }

        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public Nullable<double> InvoiceAmount { get; set; }
        public Nullable<long> PoNumber { get; set; }
        public string CheckNumber { get; set; }
        public Nullable<double> CheckAmount { get; set; }
        public string CheckDate { get; set; }
        public Nullable<double> Discount { get; set; }
        public string BalanceDue { get; set; }
        public string PaymentDate { get; set; }
        public string CheckNumberInvoice { get; set; }
        public string RefInvoiceAmount { get; set; }
        public string RefOrderNumber { get; set; }
        public string ItemBalanceDue { get; set; }
        public string RefInvoiceNumber { get; set; }
        public string RefInvoiceDate { get; set; }
        public string RefInvoiceDiscAmount { get; set; }
        public string RefInvoiceAdjNumber { get; set; }
        public double TotalQtyShipped { get; set; }
        public long TotalInvoiced { get; set; }
        public string Skus1 { get; set; }
        public string Skus2 { get; set; }
        public string TrackingID { get; set; }
        public string DiscountAmount { get; set; }
        public double WarehouseFee { get; set; }

    }
}
