
using System;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses
{
    public class ResponseBase
    {

        /// <summary>
        /// Codul de eroare care apare în timpul înregistrării unei plăți.
        /// </summary>
        [JsonProperty("errorCode")]
        public int ErrorCodeInt { get; set; }

        /// <summary>
        /// Cod de autorizare a sistemului de procesare.
        /// </summary>
        [JsonIgnore]
        public ErrorCode ErrorCode =>
            Enum.IsDefined(typeof(ErrorCode), ErrorCodeInt)
                ? (ErrorCode)ErrorCodeInt
                : ErrorCode.Unknown;

        /// <summary>
        /// Descrierea erorii.
        /// </summary>
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

    }
}
