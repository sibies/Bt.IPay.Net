using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bt.IPay.Net.General;
using Bt.IPay.Net.Requests;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class GetOrderStatusExtendedResponse : ResponseBase
    {

        public GetOrderStatusExtendedResponse()
        {
            ActionCodeInt = (int)ActionCode.Unknown;
        }
        /// <summary>
        /// Numărul (identificatorul) comenzii în sistemul comerciantului.
        /// </summary>
        [Required]
        [StringLength(32)]
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }
        /// <summary>
        /// Starea comenzii. Valoarea este selectată dintre variantele enumerate mai jos. Absent, dacă nu a fost găsită nicio comandă potrivită.
        /// </summary>
        //[StringLength(2)]
        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Se foloseste pentru a trata eventualele erori
        /// </summary>
        [JsonProperty("actionCode")]
        public int ActionCodeInt { get; set; }

        /// <summary>
        /// Cod de autorizare a sistemului de procesare.
        /// </summary>
        [JsonIgnore]
        public ActionCode ActionCode =>
            Enum.IsDefined(typeof(ActionCode), ActionCodeInt)
            ? (ActionCode)ActionCodeInt
            : ActionCode.Unknown;

        /// <summary>
        /// In cazul in care apar si alte <see cref="ActionCode"/> si nu sunt prevazute in enum.
        /// </summary>
        [JsonIgnore]
        public bool Success => ActionCode == ActionCode.Succes && OrderStatus == OrderStatus.TheAmountWasDepositedSuccessfully && ErrorCode == ErrorCode.Success;

        /// <summary>
        /// Descrierea codului furnizat de parametrul actionCode
        /// </summary>
        [StringLength(512)]
        [JsonProperty("actionCodeDescription")]
        public string ActionCodeDescription { get; set; }
        /// <summary>
        /// Suma comenzii în unități de monedă (de exemplu, bani).
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Codul monedei de plată, conform ISO 4217.
        /// </summary>
        [JsonProperty("currency")]
        public IPayCurrency Currency { get; set; }
        /// <summary>
        /// Data înregistrării comenzii
        /// </summary>
        [JsonProperty("date")]
        public long Date { get; set; }
        /// <summary>
        /// Descrierea formală a comenzii
        /// </summary>
        [JsonProperty("orderDescription")]
        public string OrderDescription { get; set; }
        /// <summary>
        /// Adresa IP a utilizatorului care a achitat comanda.
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }
        /// <summary>
        /// Identificator care este utilizat pentru o serie de plăți ulterioare care reapar până la sfârșitul perioadei de recurență. Leagă toate plățile ulterioare de plata inițială.
        /// </summary>
        [JsonProperty("recurrenceId")]
        public int RecurrenceId { get; set; }
        /// <summary>
        /// include lista de elemente secureAuthInfo și atributele: pan, dată expirare, nume deținător de card și codul de aprobare:
        /// </summary>
        [JsonProperty("cardAuthInfo")]
        public CardAuthInfo CardAuthInfo { get; set; }
        /// <summary>
        /// (include eci și elemente de tip threeDSInfo, care cuprinde o listă de cavv și xid)
        /// </summary>
        [JsonProperty("secureAuthInfo")]
        public SecureAuthInfo SecureAuthInfo { get; set; }
        /// <summary>
        /// bindingInfo (include clientId și bindingId):
        /// </summary>
        [JsonProperty("bindingInfo")]
        public BindingInfo BindingInfo { get; set; }
        /// <summary>
        /// include name si value
        /// </summary>
        [JsonProperty("merchantOrderParams")]
        public List<MerchantOrderParam> MerchantOrderParams { get; set; }
        /// <summary>
        /// include name și value
        /// </summary>
        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        /// <summary>
        /// Data și ora autorizării
        /// </summary>
        [JsonProperty("authDateTime")]
        public long AuthDateTime { get; set; }
        /// <summary>
        /// Număr de referință
        /// </summary>
        [JsonProperty("authRefNum")]
        public string AuthRefNum { get; set; }
        /// <summary>
        /// Id-ul terminalului
        /// </summary>
        [JsonProperty("terminalId")]
        public string TerminalId { get; set; }
        /// <summary>
        /// include parametrii approvedAmount, depositedAmount, refundedAmount și paymentState
        /// </summary>
        [JsonProperty("paymentAmountInfo")]
        public PaymentAmountInfo PaymentAmountInfo { get; set; }
        /// <summary>
        /// include parametrii bankName, bankCountryCode și bankCountryName
        /// </summary>
        [JsonProperty("bankInfo")]
        public BankInfo BankInfo { get; set; }

        /// <summary>
        /// Informații despre detaliile comenzii și livrare, precum și informații despre client
        /// </summary>
        [JsonProperty("orderBundle")]
        public OrderBundleResponse OrderBundle { get; set; }
    }
}
