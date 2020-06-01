using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Reqursts
{
    /// <summary>
    /// Este necesar să specificați orderId sau orderNumber în request. Dacă solicitarea conține ambii parametrii, orderId este prioritar.
    /// </summary>
    public class GetOrderStatusExtendedRequest: RequestBase
    {
        /// <summary>
        /// Numărul (identificatorul) comenzii în sistemul comerciantului.
        /// </summary>
        [StringLength(32)]
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; private set; }

        /// <summary>
        /// Număr unic de comandă în pagina de plată.
        /// </summary>
        [Required]
        [StringLength(36)]
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

    }
}