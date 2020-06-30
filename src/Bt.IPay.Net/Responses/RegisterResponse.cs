namespace Bt.IPay.Net.Responses
{
    public class RegisterResponse: ResponseBase
    {
        /// <summary>
        /// Număr unic de comandă în pagina de plată.
        /// Absent dacă înregistrarea comenzii a eșuat (eroarea este descrisă în errorCode).
        /// </summary>
        public string orderId { get; set; }
        
        /// <summary>
        /// Adresa URL a paginii de plată către care este redirecționat clientul după executarea cererii
        /// registerPreAuth.do. Un răspuns returnează:
        /// ● URL-ul paginii de plată in cazul înregistrării comenzii de succes.
        /// ● o eroare dacă înregistrarea comenzii a eșuat, eroarea este descrisă în câmpul errorCode.
        /// </summary>
        public string formUrl { get; set; }
       
        /// <summary>
        /// Identificatorul plății recurente care este utilizat pentru o serie de plăți ulterioare care
        /// reapar până la sfârșitul perioadei de recurență.
        /// </summary>
        public int? recurrenceId { get; set; }
    }
}
