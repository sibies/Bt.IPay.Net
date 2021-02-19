using System.ComponentModel.DataAnnotations;
using Bt.IPay.Net.Internal;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests.Register
{
    public class DeliveryInfo
    {
        public const string DefaultDeliveryType = "Online";
        public const string CountryCodeRomania = "642";
        public const string DefaultCity = "Sibiu";
        public const string DefaultPostalAddress = "-";
        public DeliveryInfo()
        {
            DeliveryType = DefaultDeliveryType;
            Country = CountryCodeRomania;
            City = DefaultCity;
            PostAddress = DefaultPostalAddress;
        }

        private string _deliveryType;
        /// <summary>
        /// Tipul livrării / facturării comenzii
        /// Default: <see cref="DefaultDeliveryType"/>
        /// </summary>
        [Required]
        [StringLength(20)]
        [JsonProperty("deliveryType")]
        public string DeliveryType
        {
            get => string.IsNullOrEmpty(_deliveryType) ? DefaultDeliveryType : _deliveryType.NormalizeBt().Truncate(20);
            set => _deliveryType = value;
        }

        /// <summary>
        /// Țara de livrare / facturare, conform ISO 3166-1
        /// https://www.iban.com/country-codes
        /// Default Romania: <see cref="CountryCodeRomania"/>
        /// </summary>
        [Required]
        [StringLength(3)]
        [JsonProperty("country")]
        public string Country { get; set; }

        private string _city;
        /// <summary>
        /// Orașul de livrare / facturare
        /// Default Romania: <see cref="DefaultCity"/>
        /// </summary>
        [Required]
        [StringLength(50)]
        [JsonProperty("city")]
        public string City
        {
            get => string.IsNullOrEmpty(_city) ? DefaultCity : _city.NormalizeBt().Truncate(50);
            set => _city = value;
        }

        private string _postAddress;
        /// <summary>
        /// Adresa poștală de livrare / facturare
        /// </summary>
        [StringLength(50)]
        [JsonProperty("postAddress")]
        public string PostAddress
        {
            get => string.IsNullOrEmpty(_postAddress) ? DefaultPostalAddress : _postAddress.NormalizeBt().Truncate(50);
            set => _postAddress = value;
        }

        private string _postAddress2;
        /// <summary>
        /// Rând suplimentar pentru datele de adresă
        /// </summary>
        [StringLength(50)]
        [JsonProperty("postAddress2")]
        public string PostAddress2
        {
            get => string.IsNullOrEmpty(_postAddress2) ? null : _postAddress2.NormalizeBt().Truncate(50);
            set => _postAddress2 = value;
        }

        private string _postAddress3;
        /// <summary>
        /// Rând suplimentar pentru datele de adresă
        /// </summary>
        [StringLength(50)]
        [JsonProperty("postAddress3")]
        public string PostAddress3
        {
            get => string.IsNullOrEmpty(_postAddress3) ? null : _postAddress3.NormalizeBt().Truncate(50);
            set => _postAddress3 = value;
        }
        /// <summary>
        /// Codul poștal
        /// </summary>
        [StringLength(16)]
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Statul adresei, conform ISO 3166-2
        /// </summary>
        [StringLength(3)]
        [JsonProperty("state")]
        public string State { get; set; }
    }
}