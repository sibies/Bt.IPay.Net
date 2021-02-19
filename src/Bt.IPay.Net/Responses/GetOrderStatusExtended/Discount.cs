using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class Discount
    {
        [JsonProperty("discountType")]
        public string DiscountType { get; set; }
        [JsonProperty("discountValue")]
        public string DiscountValue { get; set; }
    }
}