using System.ComponentModel.DataAnnotations;
using Bt.IPay.Net.Constants;
using Bt.IPay.Net.Internal;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests.Register
{
    /// <summary>
    /// Evitați folosirea caracterului NEWLINE (a tastei ENTER), precum și a diacriticelor în componența mesajului !
    /// </summary>
    public class CustomerDetails
    {
       
        /// <summary>
        /// Adresa de e-mail a clientului
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(254)]
        [JsonProperty("email")]
        public string Email { get; set; }

        private string _phone = ApiConsts.DefaultPhone;
        /// <summary>
        /// Numărul de telefon al clientului.
        /// Trebuie să contină doar cifre, în format internațional(de ex.40740123456).
        /// Default: <see cref="ApiConsts.DefaultPhone"/>
        /// </summary>
        [Required]
        [Phone]
        [StringLength(15)]
        [JsonProperty("phone")]
        public string Phone
        {
            get => string.IsNullOrEmpty(_phone) ? ApiConsts.DefaultPhone : _phone.GetOnlyDigits().FormatPhone().Truncate(15);
            set => _phone = string.IsNullOrEmpty(value) ? ApiConsts.DefaultPhone : value;
        }

        private string _contact;
        /// <summary>
        /// Persoană de contact
        /// </summary>
        [StringLength(40)]
        [JsonProperty("contact")]
        public string Contact
        {
            get => string.IsNullOrEmpty(_contact) ? null : _contact.NormalizeBt().Truncate(40);
            set => _contact = value;
        }

        /// <summary>
        /// Detalii despre livrarea comenzii care conțin parametrii descriși mai jos.
        /// </summary>
        [Required]
        [JsonProperty("deliveryInfo")]
        public DeliveryInfo DeliveryInfo { get; set; } = new DeliveryInfo();
        /// <summary>
        /// Detalii despre livrarea comenzii care conțin parametrii descriși mai jos.Formatul de date este același ca pentru parametrul deliveryInfo[]
        /// </summary>
        [Required]
        [JsonProperty("billingInfo")]
        public BillingInfo BillingInfo { get; set; } = new BillingInfo();
    }
}