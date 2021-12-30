using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Bt.IPay.Net.Extensions;
using Bt.IPay.Net.General;
using Bt.IPay.Net.Internal;
using Bt.IPay.Net.Requests.Register;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests
{
    /// <summary>
    /// Câmpul <see cref="OrderNumber"/> și <see cref="Description"/> acestuia sunt trimise în mod implicit procesării bancare (nu mai mult de 99 de simboluri și sunt interzise utilizarea următoarelor simboluri -%, +, \ r, \ n).
    /// </summary>
    public class RegisterRequest : RequestBase
    {
        public RegisterRequest()
        {
            //OrderNumber = Helpers.GetTimeStamp();
            //CultureInfo = CultureInfo.GetCultureInfo("RO-ro");
            //Currency = IPayCurrency.RON;
            this.Force3dSe();
        }

        /// <summary>
        /// Numărul unic (identificatorul) comenzii în sistemul comerciantului.
        /// În cazul în care este necesară reluarea tranzacției indiferent de motiv, trebuie reluat fluxul cu un nou orderNumber.
        /// Recomandăm ca orderNumber să fie asociat cu numărul facturii sau orice alt ID unic relevant + numărul iterației pentru aceeași operațiune.
        /// De exemplu: nrFactură-0, nrFactură-1,nrFactură-2 etc
        /// * Câmpul orderNumber și descrierea acestuia sunt trimise în mod implicit procesării bancare (nu mai mult de 99 de simboluri și sunt interzise utilizarea următoarelor simboluri -%, +, \ r, \ n).
        /// </summary>
        [Required]
        [StringLength(32)]
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; private set; } = Helpers.GetTimeStamp();
        /// <summary>
        /// Suma comenzii în subunități de monedă (de exemplu, bani, cenți).
        /// </summary>
        [Required]
        [StringLength(20)]
        [JsonProperty("amount")]
        public int Amount { get; set; }
        /// <summary>
        /// Codul monedei de plată, conform ISO 4217. <see cref="IPayCurrency"/>
        /// </summary>
        [Required]
        [MaxLength(999)]
        [JsonProperty("currency")]
        public IPayCurrency Currency { get; set; } = IPayCurrency.RON;
        /// <summary>
        /// Adresa web către care clientul trebuie redirecționat după finalizarea plății(atât în cazul în care plata este cu success, cât și în cazul în care plata este eșuată).
        /// Acest URL trebuie să fie pagina dvs.de finish
        /// </summary>
        [Required]
        [StringLength(512)]
        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }
        /// <summary>
        /// Descrierea comenzii.
        /// </summary>
        [StringLength(512)]
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Limba conform ISO 639-1. Dacă nu este specificată, sistemul folosește limba implicită din setările comerciantului.
        /// </summary>
        [StringLength(2)]
        [JsonProperty("language")]
        public string Language => CultureInfo.TwoLetterISOLanguageName;

        /// <summary>
        /// Adresa de e-mail a clientului
        /// </summary>
        [StringLength(254)]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.GetCultureInfo("RO-ro");

        /// <summary>
        /// Număr de rate specificat în luni(trebuie să coincidă cu una din perioadele specificate de comerciant ca fiind disponibilă)
        /// </summary>
        [StringLength(999)]
        [JsonProperty("installment")]
        public int? Installment { get; set; }
        /// <summary>
        /// Procesarea manuală a plăților recurente
        /// Pentru a înregistra o plată recurentă, acest câmp este obligatoriu(în caz contrar, plata recurentă nu va fi înregistrată).
        /// </summary>
        [JsonProperty("recurrenceType")]
        public string RecurrenceType { get; set; }

        [StringLength(99999999)]
        [JsonProperty("recurrenceStartDate")]
        public string RecurrenceStartDateString => RecurrenceStartDate?.ToString("yyyyMMdd");
        /// <summary>
        /// Data la care plata recurentă este realizată. Este utilizat pe pagina 3-D Secure și este trimis în PaReq către ACS emitent, deoarece este obligatoriu.
        /// În mod implicit, este utilizată data curentă a plății inițiale.
        ///    Formatul valorii este <yyyymmdd>.
        /// </summary>
        [JsonIgnore]
        public DateTime? RecurrenceStartDate { get; set; }

        [StringLength(99999999)]
        [JsonProperty("recurrenceEndDate")]
        public string RecurrenceEndDateString => RecurrenceEndDate?.ToString("yyyyMMdd");
        /// <summary>
        /// Data la care se încheie plata recurentă. Este utilizat pe pagina 3-D Secure și este trimis în PaReq către ACS emitent, deoarece este obligatoriu.
        /// Parametrul EPAY.RESP_CODE.EXP_DATE indică faptul că s-a terminat o perioadă de recurență a unei plăți.
        /// Formatul valorii este <yyyymmdd>.
        /// </summary>
        [JsonIgnore]
        public DateTime? RecurrenceEndDate { get; set; }
        /// <summary>
        /// Numărul clientului (ID) în sistemul comerciantului.Disponibil doar pentru comercianții cu drepturi corespunzătoare.
        /// </summary>
        [StringLength(100)]
        [JsonProperty("childId")]
        public string ChildId { get; set; }
        /// <summary>
        /// Numărul clientului (ID) în sistemul comerciantului.Disponibil doar pentru comercianții cu drepturi corespunzătoare.
        /// </summary>
        [StringLength(255)]
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Identificatorul binding care a fost creat anterior. Poate fi utilizat numai dacă comerciantul are permisiunea de a lucra cu bindings.
        /// Dacă acest parametru este trimis în cererea registerOrder, aceasta înseamnă:
        /// 1. Această comandă poate fi plătită numai prin binding
        /// 2. Plătitorul va fi redirecționat către o pagină de plată, unde este necesară numai introducerea CVC.
        /// </summary>
        [StringLength(255)]
        [JsonProperty("bindingId")]
        public string BindingId { get; set; }

        /// <summary>
        /// Valori posibile:
        /// DESKTOP - pentru a încărca pagini pentru afișarea pe monitoarele PC(pagini cu nume de payment.html);
        /// MOBILE - pentru a încărca pagini pentru afișarea pe dispozitive mobile(pagini cu nume mobile_payment.html);
        /// Valoarea implicită este pageView = DESKTOP.
        /// </summary>
        [StringLength(20)]
        [JsonProperty("pageView")]
        [Obsolete("Nu se mai foloseste")]
        public PageView PageView { get; set; }

        [Required]
        [StringLength(1024)]
        [JsonProperty("jsonParams")]
        public string JsonParamsString => Internal.JsonConverter.SerializeObject(JsonParams.Force3dSe());

        /// <summary>
        /// Câmpuri de informații suplimentare pentru stocare.Tipul este { "param": "valoare", "param2": "valoare2"}.
        /// Pentru plăți cu 3DS2, acest parametru este obligatoriu și este compus din {"FORCE_3DS2":"true"}
        /// Dacă plata în puncte de loialitate este activată pentru comerciant(poate fi activată în perioada de integrare cu acordul băncii), acest bloc ar trebui să conțină parametrul “loyaltyAmount”, a cărei valoare este suma în bani.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> JsonParams { get; set; } = new Dictionary<string, string>();

        [Required]
        [JsonProperty("orderBundle")]
        public string OrderBundleString => OrderBundle == null ? string.Empty : Internal.JsonConverter.SerializeObject(OrderBundle);

        /// <summary>
        /// Informații despre detaliile comenzii și livrare, precum și informații despre client
        /// </summary>
        [JsonIgnore]
        public OrderBundle OrderBundle { get; set; } = new OrderBundle();
    }
}
