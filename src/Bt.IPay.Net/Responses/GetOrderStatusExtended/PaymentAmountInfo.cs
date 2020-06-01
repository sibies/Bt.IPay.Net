using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class PaymentAmountInfo
    {
        /// <summary>
        /// Starea plății
        /// </summary>
        [StringLength(2)]
        [JsonProperty("paymentState")]
        public string PaymentState { get; set; }
        /// <summary>
        ///  Suma reținută pe cardul clientului
        /// </summary>
        [StringLength(20)]
        [JsonProperty("approvedAmount")]
        public int ApprovedAmount { get; set; }
        /// <summary>
        /// Suma confirmată pentru depunere
        /// </summary>
        [StringLength(20)]
        [JsonProperty("depositedAmount")]
        public int DepositedAmount { get; set; }
        /// <summary>
        /// Suma rambursată
        /// </summary>
        [StringLength(20)]
        [JsonProperty("refundedAmount")]
        public int RefundedAmount { get; set; }
    }
}