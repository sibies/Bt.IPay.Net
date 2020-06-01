using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class BankInfo
    {
        /// <summary>
        /// Denumirea băncii emitente
        /// </summary>
        [StringLength(2)]
        [JsonProperty("bankName")]
        public string BankName { get; set; }
        /// <summary>
        /// Codul țării băncii emitente
        /// </summary>
        [StringLength(2)]
        [JsonProperty("bankCountryCode")]
        public string BankCountryCode { get; set; }
        /// <summary>
        /// Țara băncii emitente
        /// </summary>
        [StringLength(2)]
        [JsonProperty("bankCountryName")]
        public string BankCountryName { get; set; }
    }
}