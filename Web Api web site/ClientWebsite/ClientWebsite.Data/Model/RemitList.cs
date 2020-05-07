using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientWebsite.Data.Model
{
    public class RemitList
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "balanceDue")]
        public string balanceDue { get; set; }
        [JsonProperty(PropertyName = "paymentDate")]
        public string paymentDate { get; set; }
        [JsonProperty(PropertyName = "checkNumber")]
        public string checkNumber { get; set; }
        [JsonProperty(PropertyName = "refInvoiceAmount")]
        public string refInvoiceAmount { get; set; }
        [Required]
        [JsonProperty(PropertyName = "refOrderNumber")]
        public string refOrderNumber { get; set; }
        [JsonProperty(PropertyName = "itemBalanceDue")]
        public string itemBalanceDue { get; set; }
        [JsonProperty(PropertyName = "refInvoiceNumber")]
        public string refInvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "refInvoiceDate")]
        public string refInvoiceDate { get; set; }
        [JsonProperty(PropertyName = "refInvoiceDiscAmount")]
        public string refInvoiceDiscAmount { get; set; }
        [JsonProperty(PropertyName = "refInvoiceAdjNumber")]
        public string refInvoiceAdjNumber { get; set; }
    }
}