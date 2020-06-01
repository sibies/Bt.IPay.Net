using Newtonsoft.Json;

namespace Bt.IPay.Net.Reqursts.Register
{
    public class OrderBundle
    {
        [JsonProperty("orderCreationDate")]
        public string OrderCreationDate { get; set; }
        [JsonProperty("customerDetails")]
        public CustomerDetails CustomerDetails { get; set; }
    }
}