namespace Bt.IPay.Net.Responses
{
    public enum ActionCode
    {
        /// <summary>
        /// Transaction  is  rejected  since  the  amount exceeds the limits  specified  by  the  Issuing bank
        /// </summary>
        BLOCKED_BY_LIMIT = -20010,
        /// <summary>
        /// State of the transaction start
        /// </summary>
        Started = -9000,
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = -3003,
        /// <summary>
        /// Reject by the passenger name
        /// </summary>
        BlockingByAPassengerName = -2102,
        /// <summary>
        /// Reject by email
        /// </summary>
        BlockingByEmail = -2101,
        /// <summary>
        /// Invalid ECI.
        /// This code means that ECI received in PaRes is not valid for the IPN.The rule applies only toMastercard (the available values -01,02) and Visa (the available values -05,06)
        /// </summary>
        IncorrectECIreceived = -2020,
        /// <summary>
        /// PARes from the issuing bank contains iReq, which caused the payment rejection
        /// </summary>
        DeclineByIReqInPARes = -2019,
        /// <summary>
        /// There is no access to the Directory server Visa or MaterCard;or a connection error occurred after a card involvement request (VeReq).
        /// This is an error of interaction between the payment gate and IPN servers due to technical problems on the side of IPN servers.
        /// </summary>
        DeclinedDSConnectionTimeout = -2018,
        /// <summary>
        /// Rejected. PAResstatus is not "Y"
        /// </summary>
        DeclinedThePAResstatusIsNotY = -2017,
        /// <summary>
        /// Issuing bank could not determine if the card is 3-D Secure.
        /// </summary>
        DeclinedVeResStatusIsUnknown = -2016,
        /// <summary>
        /// VERes from DS contains iReq, which caused the payment rejection.
        /// </summary>
        DeclineByiReqqInVERes = -2015,
        /// <summary>
        /// All attempts  to  perform  a payment are used.
        /// </summary>
        AllPaymentAttemptsWereUsed = -2013,

        /// <summary>
        /// This operation is not supported.
        /// </summary>
        OperationNotSupported = -2012,
        /// <summary>
        /// Issuing bank was not able to perform the 3-D Secure card authorization.
        /// </summary>
        DeclinedPaResStatusIsUnknown = -2011,
        /// <summary>
        /// XID mismatch
        /// </summary>
        XIDmismatch = -2010,
        /// <summary>
        /// Wrong wallet.
        /// </summary>
        IncorrectWallet = -2008,
        /// <summary>
        /// The period allotted to enter the card details has  expired (by default the timeout is 20 minutes; the session duration may be specified while registering an order;
        /// if the merchant has "Alternative session timeout" permission, then the timeout duration is specified in merchant settings)
        /// </summary>
        DeclinePaymentTimeLimit = -2007,
        /// <summary>
        /// Means that the issuing bank rejected authentication (3DS authorization has not been performed).
        /// </summary>
        Decline3DSecDecline = -2006,
        /// <summary>
        /// Issuing bank sign could not be checked, i.e. PARes was readable but the sign was wrong.
        /// </summary>
        Decline3DSecSignError = -2005,
        /// <summary>
        /// Blocking bytheport.
        /// </summary>
        BlockingByThePort = -2003,
        /// <summary>
        /// Transaction was rejected because the payment amount exceeded the established limits.
        /// Note: it could be the limit of the day withdrawal established by the acquiring Bank, or the limit of transactions by one card established by the merchant, or the limit for one transaction established by a merchant.
        /// </summary>
        DeclinePaymentOverLimit = -2002,
        /// <summary>
        /// Transaction is rejected since Client's IP-address is in the black list.
        /// </summary>
        DeclineIPBlacklisted = -2001,
        /// <summary>
        /// Transaction is rejected since the card number is in the black list
        /// </summary>
        DeclinePANBlacklisted = -2000,
        /// <summary>
        /// The payment was cancelled by the payment agent
        /// </summary>
        APaymentIsCancelledByThePaymentAgent = -102,
        /// <summary>
        /// There were not payment attempts.
        /// </summary>
        NoPaymentsYet = -100,
        /// <summary>
        /// The timer of waiting for aprocessing response has expired.
        /// </summary>
        SvUnavailable = -1,
        /// <summary>
        /// Tranzactie cu succes
        /// Approved
        /// Payment has been performed successfully
        /// </summary>
        Succes = 0,
        /// <summary>
        /// Proof of identity is necessary for successful completion of the transaction.
        /// In case of an internet transaction (our case) it is impossible, so the transaction is considered as declined.
        /// </summary>
        Declined = 1,
        /// <summary>
        /// Rejectionof the network to process atransaction.
        /// </summary>
        DeclineUnableToProcess = 5,
        /// <summary>
        /// Card limits (the Issuing bank forbade internet transactions by the card).
        /// </summary>
        DeclineCardDeclined = 100,
        /// <summary>
        /// Card is expired
        /// </summary>
        DeclineExpiredCard = 101,
        /// <summary>
        /// There is no connection tothe Issuing bank. The sales outlet needs to contact the Issuing bank.
        /// </summary>
        DeclineCallIssuer = 103,
        /// <summary>
        /// This is an attempt to perform a transaction by the account that has restrictions for use.
        /// </summary>
        DeclineCardDeclined2 = 104,
        /// <summary>
        /// The maximum number of attempts to enter PIN is exceeded. It is possible that the card is blocked temporary.
        /// </summary>
        TheMaximumNumberOfAttemptsToEnterPinIsExceeded = 106,
        /// <summary>
        /// Please, contact the Issuing bank.
        /// </summary>
        DeclineCallIssuer2 = 107,
        /// <summary>
        /// Merchant/terminal identifier is incorrect or ACC is blocked at the processing level.
        /// </summary>
        DeclineInvalidMerchant = 109,
        /// <summary>
        /// Transaction amount is incorrect.
        /// </summary>
        DeclineInvalidAmount = 110,
        /// <summary>
        /// Card number is incorrect
        /// </summary>
        DeclineNoCardRecord = 111,
        /// <summary>
        /// Transaction  amount  exceeds  the  available balance of the selected account
        /// </summary>
        DeclineNotEnoughMoney = 116,
        /// <summary>
        /// Incorrect PIN (not for internet transactions)
        /// </summary>
        IncorrectPin = 117,
        /// <summary>
        /// Decline. SECURITY_VIOLATION from processing system
        /// </summary>
        IllegalTransaction = 119,
        /// <summary>
        /// Refusal to perform the operation
        /// -the transaction is not allowed by the Issuing bank.
        /// The response code of the IPN is 57.
        /// Reasons for rejection should be specified by the issuing bank.
        /// </summary>
        DeclineNotAllowed = 120,
        /// <summary>
        /// This is an attempt to perform a transaction of the amount exceeding the day limit established by the issuing bank.
        /// </summary>
        DeclineExcdsWdrwlLimt = 121,
        /// <summary>
        /// The client has performed the maximum number of transactions during the limit cycle and tries to perform another one.
        /// </summary>
        DeclineExcdsWdrwlLtmt = 123,
        /// <summary>
        /// Card number is incorrect.
        /// This error may have several meanings:
        /// An attempt to perform a refund of the amount exceeding the hold amount;
        /// An  attempt  to  refund a zero amount;
        /// for Am Ex –the expiry date is specified incorrectly.
        /// </summary>
        DeclineCardDeclined3 = 125,
        /// <summary>
        /// Decline. Card is lost
        /// </summary>
        DeclineCardIsLost = 208,
        /// <summary>
        /// Decline. Card limitations exceeded
        /// </summary>
        CardLimitationsExceeded = 209,

        /// <summary>
        /// Card inactiv. Vă rugăm activați cardul.
        /// </summary>
        CardInactiv = 320,

        /// <summary>
        /// Reversal is processed
        /// </summary>
        TheReversalIsProcessed = 400,

        /// <summary>
        /// Emitent indisponibil
        /// </summary>
        EmitentIndosponibil = 801,
        /// <summary>
        /// Card blocat. Vă rugăm contactați banca emitentă.
        /// </summary>
        CardBlocat = 803,
        /// <summary>
        /// Tranzacția nu este permisă
        /// </summary>
        TranzactiaNuEstePermisa = 804,
        /// <summary>
        /// Tranzacție respinsă.
        /// </summary>
        TranzactieRespinsa = 805,
        /// <summary>
        /// Dată expirare card greșită.
        /// </summary>
        DataExpirareCardGresita = 861,
        /// <summary>
        /// CVV gresit
        /// </summary>
        CvvGresit = 871,

        /// <summary>
        /// Card  limitations  (the  cardholder  tries  to perform  a  transaction that  is forbidden  for him).
        /// </summary>
        DeclineInvalidTrans = 902,
        /// <summary>
        /// Attempt to perform a transaction of amount exceeding Issuing bank limit.
        /// </summary>
        DeclineReEnterTrans = 903,
        /// <summary>
        /// The message format is incorrect in terms of the issuing bank.
        /// </summary>
        DeclineFormatError = 904,
        /// <summary>
        ///  Card invalid. Acesta nu există în baza de date.
        /// </summary>
        CardInvalid = 905,
        /// <summary>
        /// Card expirat.
        /// </summary>
        CardGresit = 906,

        /// <summary>
        /// There is no connection tothe Issuing bank.
        /// Authorization in the stand-in mode is not allowed for this card number
        /// (this mode means that the Issuing bank is unable to connect to the IPN, and therefore the transaction can be either offline with further unloading to back office, or it can be declined).
        /// </summary>
        DeclineTheHostisnotAvailable = 907,
        /// <summary>
        /// Operation  is  impossible  (a  general  error  of the system functioning. May be detected by IPN or the Issuing bank).
        /// </summary>
        DeclineCallIssuer3 = 909,
        /// <summary>
        /// Issuing bank is not available.
        /// </summary>
        DeclineTheHostisnotAvailable2 = 910,
        /// <summary>
        /// The message format is incorrect in terms of IPN.
        /// </summary>
        DeclineInvalidTrans2 = 913,
        /// <summary>
        /// Transaction  is  not  found  (when  sending  a completion, reversal or refund request).
        /// </summary>
        DeclineOrigTransNotFound = 914,

        ///// <summary>
        ///// Cont invalid. Vă rugăm contactați banca emitentă.
        ///// </summary>
        //[Obsolete("Vazut daca mai trebuie")]
        //ContInvalid = 914,

        /// <summary>
        /// Fonduri insuficiente.
        /// </summary>
        FonduriInsuficiente = 915,
        /// <summary>
        /// Limită tranzacționare depășită.
        /// </summary>
        LimitaTranzactieDepasita = 917,

        /// <summary>
        /// Tranzacția în rate nu este permisă cu acest card. Te rugăm să folosești un card de credit emise de Banca Transilvania.
        /// </summary>
        TranzacțiaInRateNuEstePermisăCuAcestCard = 998,
        /// <summary>
        /// The beginning of the transaction authorization is missed. Declined by fraud.
        /// </summary>
        DeclinedByFraud = 999,
        /// <summary>
        /// Empty (is specified at the moment of the transaction authorization, when card details are not entered yet).
        /// </summary>
        DeclineDataInputTimeout = 1001,
        /// <summary>
        /// Authorization phase 1
        /// </summary>
        AuthorizationPhase1 = 1004,
        /// <summary>
        /// Authorization phase 2
        /// </summary>
        AuthorizationPhase2 = 1005,
        /// <summary>
        /// Fraud (in terms of IPN)
        /// </summary>
        DeclineFraud = 2001,
        /// <summary>
        /// Incorrect operation
        /// </summary>
        IncorrectOperation = 2002,
        /// <summary>
        /// SSL (not 3-D Secure/SecureCode) transactions are forbidden for the Merchant.
        /// </summary>
        DeclineSSLRestricted = 2003,
        /// <summary>
        /// Payment through SSL without CVC2 is forbidden.
        /// </summary>
        SSLWithoutCVCForbidden = 2004,
        /// <summary>
        /// Payment does not meet the terms of the rule of 3-D Secure validation.
        /// </summary>
        X3DSRuleFailed = 2005,
        /// <summary>
        /// One-phase payments are forbidden
        /// </summary>
        OnePhasePaymentsAreForbidden = 2006,
        /// <summary>
        /// The order is paid
        /// </summary>
        TheOrderIsPaid = 2007,
        /// <summary>
        /// The transaction is not completed
        /// </summary>
        TheTransactionIsNotCompleted = 2008,
        /// <summary>
        /// Refund amount exceeds the payment amount
        /// </summary>
        RefundAmountExceedsThePaymentamount = 2009,
        /// <summary>
        /// Error of a 3-D Secure rule execution.
        /// </summary>
        ErrorOfA3DSecureRuleExecution = 2014,
        /// <summary>
        /// Terminal select rule error
        /// </summary>
        TerminalSelectRuleError = 2015,
        /// <summary>
        /// Internal error
        /// </summary>
        InternalError = 9001,
        /// <summary>
        /// Entered card details are incorrect.
        /// </summary>
        DeclineInputError = 71015,
        /// <summary>
        /// 3-D Secure -communication error
        /// </summary>
        Decline3DSecCommError = 151017,
        /// <summary>
        /// Processing timeout. Sending is failed.
        /// </summary>
        DeclineProcessingTimeout = 151018,
        /// <summary>
        /// Processing timeout. Sending is successful; a response from the bank was not received.
        /// </summary>
        DeclineProcessingTimeout1 = 151019,
        /// <summary>
        /// General error
        /// </summary>
        DeclineGeneralError = 341014,
        /// <summary>
        /// 3DS2 authentication is declined by Authentication Response (ARes)
        /// </summary>
        AuthenticationResponseARes = 341016,
        /// <summary>
        /// 3DS2 authentication status in ARes is unknown
        /// </summary>
        AResIsUnknown = 341017,
        /// <summary>
        /// 3DS2 CReq cancelled
        /// </summary>
        CReqCancelled = 341018,
        /// <summary>
        /// 3DS2 CReq failed
        /// </summary>
        CReqFailed = 341019,
        /// <summary>
        /// 3DS2 unknown status in RReq
        /// </summary>
        RReqUnknownStatus = 341020
    }
}
