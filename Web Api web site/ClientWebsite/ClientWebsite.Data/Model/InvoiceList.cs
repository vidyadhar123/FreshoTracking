using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientWebsite.Data.Model
{
    public class InvoiceList
    {
        public int Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Invoice Number")]
        public string InvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "Invoice Date")]
        public string InvoiceDate { get; set; }
        [JsonProperty(PropertyName = "Invoice Amount")]
        public Nullable<double> InvoiceAmount { get; set; }
        [JsonProperty(PropertyName = "PO Number")]
        public Nullable<long> PoNumber { get; set; }
        [JsonProperty(PropertyName = "Check Number")]
        public Nullable<long> CheckNumber { get; set; }
        [JsonProperty(PropertyName = "Check Amount")]
        public Nullable<double> CheckAmount { get; set; }
        [JsonProperty(PropertyName = "Check Date")]
        public string CheckDate { get; set; }
        [JsonProperty(PropertyName = "Discount")]
        public Nullable<double> Discount { get; set; }
    }
}
