using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    /// <summary>
    /// (include eci și elemente de tip threeDSInfo, care cuprinde o listă de cavv și xid)
    /// </summary>
    public class SecureAuthInfo
    {
        /// <summary>
        /// Electronic Commerce Indicator.
        /// </summary>
        [JsonProperty("eci")]
        public string Eci { get; set; }

        /// <summary>
        /// Cardholder Authentication Verification Value
        /// </summary>
        [JsonProperty("cavv")]
        public string Cavv { get; set; }
        /// <summary>
        /// Electronic Commerce Transaction Identifier
        /// </summary>
        [JsonProperty("xid")]
        public string Xid { get; set; }
    }
}