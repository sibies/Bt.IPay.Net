using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class CardAuthInfo
    {
        /// <summary>
        /// Data de expirare a cardului în format YYYYMM. Precizat numai pentru comenzile plătite.
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; set; }
        
        /// <summary>
        /// Nume deținător de card. Precizat numai pentru comenzile plătite.
        /// </summary>
        [JsonProperty("cardholderName")]
        public string CardholderName { get; set; }
        
        /// <summary>
        /// Cod de autorizare IPS.
        /// </summary>
        [JsonProperty("approvalCode")]
        public string ApprovalCode { get; set; }
        
        /// <summary>
        /// Numărul mascat al cardului care a fost utilizat la plată. Precizat numai pentru comenzile plătite.
        /// </summary>
        [JsonProperty("pan")]
        public string Pan { get; set; }
    }
}
