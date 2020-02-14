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
        public int date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int total { get; set; }
        public int fee { get; set; }
        public long ship_date { get; set; }
        public string carrier { get; set; }
        public string method { get; set; }
        public int weight { get; set; }
        public string tracking { get; set; }
        public int postage { get; set; }
        public string items { get; set; }
        public int qtys { get; set; }
        public string skus { get; set; }
        public int subtotals { get; set; }
    }
}
