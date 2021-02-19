using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests
{
    /// <summary>
    /// Este necesar să specificați orderId sau orderNumber în request. Dacă solicitarea conține ambii parametrii, orderId este prioritar.
    /// </summary>
    public class GetOrderStatusExtendedRequest : RequestBase
    {
        /// <summary>
        /// Numărul unic (identificatorul) comenzii în sistemul comerciantului.
        /// În cazul în care este necesară reluarea tranzacției indiferent de motiv, trebuie reluat fluxul cu un nou orderNumber.
        /// Recomandăm ca orderNumber să fie asociat cu numărul facturii sau orice alt ID unic relevant + numărul iterației pentru aceeași operațiune.
        /// De exemplu: nrFactură-0, nrFactură-1, nrFactură-2 etc
        /// </summary>
        [StringLength(32)]
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; private set; }

        /// <summary>
        /// Număr unic de comandă în pagina de plată.
        /// </summary>
        [Required]
        [StringLength(36)]
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }
}
