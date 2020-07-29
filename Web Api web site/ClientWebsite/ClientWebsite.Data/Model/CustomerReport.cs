using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebsite.Data.Model
{
    public class CustomerReport
    {
        public int id { get; set; }
        public string order_source { get; set; }
        public string txn_id { get; set; }
        public string date { get; set; }
        public double total { get; set; }
        public double fee { get; set; }
        public string carrier { get; set; }
        public string method { get; set; }
        public double weight { get; set; }
        public string tracking { get; set; }
        public double postage { get; set; }
        public string item_name { get; set; }
        public int quantity { get; set; }
        public string item_sku { get; set; }
        public double subtotals { get; set; }
        public int queue_id { get; set; }
        public string item_description { get; set; }
        public string line_number { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public double num_order_lines { get; set; }
        public string payment_type { get; set; }
        public string postage_account { get; set; }
        public string ship_date { get; set; }
        public double shipping { get; set; }
        public string status { get; set; }
        public long subtotal { get; set; }
        public double tax { get; set; }
        public double tnx_seq { get; set; }

    }
}

