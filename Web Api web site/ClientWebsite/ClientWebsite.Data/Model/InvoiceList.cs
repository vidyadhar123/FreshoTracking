using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebsite.Data.Model
{
    public class InvoiceList
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Invoice Number")]
        public long InvoiceNumber {get;set;}
        [JsonProperty(PropertyName = "Invoice Date")]
        public long InvoiceDate { get; set; }
        [JsonProperty(PropertyName = "Invoice Amount")]
        public double InvoiceAmount { get; set; }
        [JsonProperty(PropertyName = "PO Number")]
        public long PoNumber { get; set; }
        [JsonProperty(PropertyName = "Check Number")]
        public long CheckNumber { get; set; }
        [JsonProperty(PropertyName = "Check Amount")]
        public double CheckAmount { get; set; }
        [JsonProperty(PropertyName = "Check Date")]
        public string CheckDate { get; set; }
        [JsonProperty(PropertyName = "Discount")]
        public double Discount { get; set; }
    }
}
