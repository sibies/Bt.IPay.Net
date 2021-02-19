namespace Bt.IPay.Net.Responses
{
    public enum ErrorCode
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = -3003,
        /// <summary>
        /// Nicio eroare de sistem
        /// errorMessage:
        ///     No system error
        /// </summary>
        Success = 0,
        /// <summary>
        /// orderNumber duplicat, comanda cu numărul de comandă dat este deja procesată
        /// Expected [orderId] or [orderNumber]
        /// errorMessage:
        ///     Order with this number was already processed.
        ///     Order with this number was registered, but was not paid off.
        ///     Invalid orderNumber
        ///     Submerchant could not be found
        ///     Submerchant is blocked or deleted
        /// </summary>
        OrderNumberDuplicated = 1,
        /// <summary>
        /// Comanda este refuzată din cauza unei erori în credentialele de plată
        /// </summary>
        OrderRejected = 2,
        /// <summary>
        /// Valută necunoscută
        /// errorMessage:
        ///     Unknown currency.
        /// </summary>
        UnknownCurrency = 3,
        /// <summary>
        /// Parametrul solicitării obligatorii nu a fost specificat
        /// errorMessage:
        ///     Order number is empty
        ///     Empty merchant user name
        ///     Empty amount
        ///     Return URL cannot be empty
        ///     Password cannot be empty
        /// </summary>
        MissingMandatoryRequestParameter = 4,
        /// <summary>
        /// Valoare eronată a unui parametru din solicitare
        /// errorMessage:
        ///     Invalid value of one of the parameters.
        ///     Wrong value of the language parameter
        ///     Access denied
        ///     The user must change his password
        ///     Invalid [jsonParams]
        ///     Pre-authorization payment is restricted
        /// </summary>
        RequestParameterVaueError = 5,
        /// <summary>
        /// orderId neînregistrat
        /// </summary>
        OrderIdNotRegistred = 6,
        /// <summary>
        /// Eroare de sistem
        /// errorMessage:
        ///     System error
        /// </summary>
        SystemError = 7,
        /// <summary>
        /// Eroare in orderbundle
        /// errorMessage:
        ///     [orderBundle.customerDetails.*] wrong
        /// </summary>
        OrderBundleError = 8,
    }
}
