using Bt.IPay.Net.Requests.Register;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class OrderBundleResponse
    {
        /// <summary>
        /// Data comenzii. Format dată unix
        /// </summary>
        [JsonProperty("orderCreationDate")]
        public int OrderCreationDate { get; set; }

        /// <summary>
        /// Detalii despre client. Consultați descrierea conținutului acestui bloc mai jos.
        /// </summary>
        [JsonProperty("customerDetails")]
        public CustomerDetails CustomerDetails { get; set; }
    }
}