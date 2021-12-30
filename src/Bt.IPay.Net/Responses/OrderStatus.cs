namespace Bt.IPay.Net.Responses
{
    public enum OrderStatus
    {
        /// <summary>
        /// Order registered, but not paid off
        /// </summary>
        OrderRegisteredButNotPaidOff = 0,

        /// <summary>
        /// Pre-authorization amount was held (for two-phase payment)
        /// </summary>
        PreAuthorizationAmountWasHeld = 1,

        /// <summary>
        /// The amount was deposited successfully
        /// </summary>
        TheAmountWasDepositedSuccessfully = 2,

        /// <summary>
        /// Authorization reversed
        /// </summary>
        AuthorizationReversed = 3,

        /// <summary>
        /// Transaction was refunded
        /// </summary>
        TransactionWasRefunded = 4,

        /// <summary>
        /// Authorization through the issuer's ACS initiated
        /// </summary>
        AuthorizationThroughTheIssuersAcsInitiated = 5,

        /// <summary>
        /// Authorization declined
        /// </summary>
        AuthorizationDeclined = 6,

        /// <summary>
        /// Transaction was partially refunded
        /// </summary>
        TransactionWasPartiallyRefounded = 7,
    }
}
