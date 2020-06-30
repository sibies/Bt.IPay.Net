
namespace Bt.IPay.Net.Responses
{
    public class ResponseBase
    {
        /// <summary>
        /// Codul de eroare care apare în timpul înregistrării unei plăți.
        /// </summary>
        public ErrorCode errorCode { get; set; }
        
        /// <summary>
        /// Descrierea erorii.
        /// </summary>
        public string errorMessage { get; set; }
    }
}
