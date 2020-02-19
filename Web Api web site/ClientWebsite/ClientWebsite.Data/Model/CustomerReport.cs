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
        public double date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public double total { get; set; }
        public double fee { get; set; }
        public long ship_date { get; set; }
        public string carrier { get; set; }
        public string method { get; set; }
        public double weight { get; set; }
        public string tracking { get; set; }
        public double postage { get; set; }
        public string items { get; set; }
        public int qtys { get; set; }
        public string skus { get; set; }
        public double subtotals { get; set; }
    }
}
