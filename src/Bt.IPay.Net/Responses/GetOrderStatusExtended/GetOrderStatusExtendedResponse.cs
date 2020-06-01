using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class GetOrderStatusExtendedResponse : ResponseBase
    {

        /// <summary>
        /// Numărul (identificatorul) comenzii în sistemul comerciantului.
        /// </summary>
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }
        /// <summary>
        /// Starea comenzii. Valoarea este selectată dintre variantele enumerate mai jos. Absent, dacă nu a fost găsită nicio comandă potrivită.
        /// </summary>
        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Cod de autorizare a sistemului de procesare.
        /// </summary>
        [JsonProperty("actionCode")]
        public ActionCode ActionCode { get; set; }
        /// <summary>
        /// Descrierea codului furnizat de parametrul actionCode
        /// </summary>
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
        public int Currency { get; set; }
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
        /// include lista de elemente secureAuthInfo și atributele: pan, dată expirare, nume deținător de card și codul de aprobare:
        /// </summary>
        [JsonProperty("cardAuthInfo")]
        public CardAuthInfo CardAuthInfo { get; set; }
        /// <summary>
        /// Data și ora autorizării
        /// </summary>
        [JsonProperty("authDateTime")]
        public long AuthDateTime { get; set; }
        /// <summary>
        /// Id-ul terminalului
        /// </summary>
        [JsonProperty("terminalId")]
        public string TerminalId { get; set; }
        /// <summary>
        /// Număr de referință
        /// </summary>
        [JsonProperty("authRefNum")]
        public string AuthRefNum { get; set; }
        /// <summary>
        /// include parametrii approvedAmount,depositedAmount,refundedAmount și paymentState
        /// </summary>
        [JsonProperty("paymentAmountInfo")]
        public PaymentAmountInfo PaymentAmountInfo { get; set; }
        /// <summary>
        /// include parametrii bankName,bankCountryCodeșibankCountryName
        /// </summary>
        [JsonProperty("bankInfo")]
        public BankInfo BankInfo { get; set; }
    }
}