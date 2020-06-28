using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Bt.IPay.Net.Internal;
using Bt.IPay.Net.Requests.Register;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests
{
    /// <summary>
    /// Câmpul <see cref="OrderNumber"/> și <see cref="Description"/> acestuia sunt trimise în mod implicit procesării
    /// bancare (nu mai mult de 99 de simboluri și sunt interzise utilizarea următoarelor simboluri -%, +, \ r, \ n).
    /// </summary>
    public class RegisterRequest:RequestBase
    {
        public RegisterRequest()
        {
            OrderNumber = Helpers.GetTimeStamp();
            PageView = PageView.DESKTOP;
            CultureInfo = CultureInfo.CurrentCulture;
        }
       
        /// <summary>
        /// Numărul (identificatorul) comenzii în sistemul comerciantului.
        /// </summary>
        [Required]
        [StringLength(32)]
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; private set; }

        /// <summary>
        /// Suma comenzii în unități de monedă (de exemplu, bani).
        /// </summary>
        [Required]
        [StringLength(20)]
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Codul monedei de plată, conform ISO 4217. <see cref="IPayCurrency"/>
        /// </summary>
        [Required]
        [MaxLength(9999)]
        [JsonProperty("currency")]
        public IPayCurrency Currency { get; set; }

        /// <summary>
        /// Adresa web la care clientul trebuie să fie redirecționat după finalizarea plății.
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
        /// Limba conform ISO 639-1. Dacă nu este specificată, sistemul folosește limba implicită din setările
        /// comerciantului. <see cref="CultureInfo"/>
        /// </summary>
        [StringLength(2)]
        [JsonProperty("language")]
        public string Language => CultureInfo.TwoLetterISOLanguageName;

        /// <summary>
        /// Valori posibile:
        /// DESKTOP - pentru a încărca pagini pentru afișarea pe monitoarele PC(pagini cu nume de payment.html);
        /// MOBILE - pentru a încărca pagini pentru afișarea pe dispozitive mobile(pagini cu nume mobile_payment.html);
        /// Valoarea implicită este pageView = DESKTOP.
        /// </summary>
        [StringLength(20)]
        [JsonProperty("pageView")]
        public PageView PageView { get; set; }

        /// <summary>
        /// Procesarea manuală a plăților recurente
        /// Pentru a înregistra o plată recurentă, acest câmp este obligatoriu(în caz contrar, plata recurentă
        /// nu va fi înregistrată).
        /// </summary>
        [JsonProperty("recurrenceType")]
        public string RecurrenceType { get; set; }

        /// <summary>
        /// Data la care plata recurentă este realizată. Este utilizat pe pagina 3-D Secure și este trimis în PaReq
        /// către ACS emitent, deoarece este obligatoriu.
        /// În mod implicit, este utilizată data curentă a plății inițiale.
        ///    Formatul valorii este<yyyymmdd>.
        /// </summary>
        [StringLength(8)]
        [JsonProperty("recurrenceStartDate")]
        public int? RecurrenceStartDate { get; set; }

        /// <summary>
        /// Data la care se încheie plata recurentă. Este utilizat pe pagina 3-D Secure și este trimis în PaReq către
        /// ACS emitent, deoarece este obligatoriu.
        /// Parametrul EPAY.RESP_CODE.EXP_DATE indică faptul că s-a terminat o perioadă de recurență a unei plăți.
        /// Valoarea implicită EPAY.RESP_CODE.EXP_DATE este 33.
        /// Formatul valorii este<yyyymmdd>.
        /// </summary>
        [StringLength(8)]
        [JsonProperty("recurrenceEndDate")]
        public int? RecurrenceEndDate { get; set; }

        /// <summary>
        /// Identificatorul subcomerciantului care trebuie să aparțină comerciantului agregator.
        /// </summary>
        [StringLength(100)]
        [JsonProperty("childId")]
        public string ChildId { get; set; }

        /// <summary>
        /// Numărul clientului (ID) în sistemul comerciantului. Disponibil doar pentru comercianții
        /// cu drepturi corespunzătoare.
        /// </summary>
        [StringLength(255)]
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Identificatorul binding care a fost creat anterior. Poate fi utilizat numai dacă comerciantul are
        /// permisiunea de a lucra cu bindings. Dacă acest parametru este trimis în cererea registerOrder,
        /// aceasta înseamnă:
        /// 1. Această comandă poate fi plătită numai prin binding
        /// 2. Plătitorul va fi redirecționat către o pagină de plată, unde este necesară numai introducerea CVC.
        /// </summary>
        [StringLength(255)]
        [JsonProperty("bindingId")]
        public string BindingId { get; set; }

        /// <summary>
        /// Câmpuri de informații suplimentare pentru stocare. Tipul este {"param": "valoare", "param2": "valoare2"}.
        /// Această funcționalitate poate fi activată în perioada de integrare cu acordul băncii.
        /// Dacă plata în puncte de loialitate este activată pentru comerciant, acest bloc ar trebui să conțină
        /// parametrul “loyaltyAmount”, a cărei valoare este suma în bani.
        /// Dacă notificarea clientului este activată pentru comerciant, acest bloc ar trebui să conțină parametrul
        /// „e-mail” a carui valoare este e-mail clientului.
        /// </summary>
        [StringLength(1024)]
        [JsonProperty("jsonParams")]
        public string JsonParamsString => JsonParams == null
            ? string.Empty
            : Internal.JsonConverter.SerializeObject(JsonParams);

        [JsonIgnore]
        public Dictionary<string,string> JsonParams { get; set; }

        /// <summary>
        /// Nu este specificat in documentatie
        /// Este un obiect json serializat ca string
        /// </summary>
        [JsonProperty("orderBundle")]
        public string OrderBundleString => OrderBundle == null
            ? string.Empty
            : Internal.JsonConverter.SerializeObject(OrderBundle);

        [JsonIgnore]
        public OrderBundle OrderBundle { get; set; } 
       
        [JsonIgnore]
        public CultureInfo CultureInfo { get; set; }
    }
}
