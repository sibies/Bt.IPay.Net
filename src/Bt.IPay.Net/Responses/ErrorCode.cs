namespace Bt.IPay.Net.Responses
{
    public enum ErrorCode
    {
        /// <summary>
        /// Nicio eroare de sistem
        /// </summary>
        Success = 0,
        
        /// <summary>
        /// orderNumber duplicat, comanda cu numărul de comandă dat este deja procesată
        /// Expected [orderId] or [orderNumber]
        /// </summary>
        OrderNumberDuplicated = 1,
        
        /// <summary>
        /// Valută necunoscută
        /// </summary>
        UnknownCurrency = 3,
        
        /// <summary>
        /// Parametrul solicitării obligatorii nu a fost specificat
        /// </summary>
        MissingMandatoryRequestParameter = 4,
        
        /// <summary>
        /// Valoare eronată a unui parametru din solicitare
        /// </summary>
        RequestParameterVaueError = 5,
        
        /// <summary>
        /// Eroare de sistem
        /// </summary>
        SystemError = 6,
    }
}
