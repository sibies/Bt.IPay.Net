using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests.Register
{
    public class OrderBundle
    {
        [JsonProperty("orderCreationDate")]
        public string OrderBundleString => OrderCreationDate.ToString("yyyy-MM-dd");
        /// <summary>
        /// Data comenzii. Format dată yyyy-MM-dd
        /// </summary>
        [JsonIgnore]
        public DateTime OrderCreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Detalii despre client. Consultați descrierea conținutului acestui bloc mai jos.
        /// </summary>
        [Required]
        [JsonProperty("customerDetails")]
        public CustomerDetails CustomerDetails { get; set; } = new CustomerDetails();
    }
}