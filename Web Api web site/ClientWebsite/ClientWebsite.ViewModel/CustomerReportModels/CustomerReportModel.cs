using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebsite.ViewModel.CustomerReportModels
{
    public class CustomerReportModel
    {
        public string orderSource { get; set; }
        public string txnId { get; set; }
        public int date { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int total { get; set; }
        public int fee { get; set; }
        public long shipDate { get; set; }
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
