using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests
{
    public class RequestBase
    {
        /// <summary>
        /// User API comerciant.
        /// </summary>
        [Required]
        [StringLength(30)]
        [JsonProperty("userName")]
        public string UserName { get; internal set; }
        /// <summary>
        /// Parolă API comerciant.
        /// </summary>
        [Required]
        [StringLength(30)]
        [JsonProperty("password")]
        public string Password { get; internal set; }
    }
}