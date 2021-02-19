using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class BindingInfo
    {
        /// <summary>
        /// Numărul clientului (ID) în sistemul comerciantului, transferat în timpul înregistrării comenzii.
        /// Disponibil doar pentru comercianții cu drepturi corespunzătoare.
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Identificatorul binding creat în timpul plății comenzii sau utilizat pentru plată.
        /// Disponibil doar pentru comercianții cu drepturi corespunzătoare.
        /// </summary>
        [JsonProperty("bindingId")]
        public string BindingId { get; set; }
    }
}