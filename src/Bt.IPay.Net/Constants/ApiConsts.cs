namespace Bt.IPay.Net.Constants
{
    public static class ApiConsts
    {
        public const string Version = "2.2.0.0";
        public const string DefaultPhone = "40799999999";

        public static class Production
        {
            public const string BaseApiUrl = "https://ecclients.btrl.ro";
            public const string BaseApiPath = BaseApiUrl + "/payment/rest";
            public const string BaseRegisterApiPath = BaseApiPath + "/register.do";
            public const string BaseRegisterPreAuthApiPath = BaseApiPath + "/registerPreAuth.do";
            public const string BaseGetOrderStatusApiPath = BaseApiPath + "/getOrderStatus.do";
            public const string BaseGetOrderStatusExtendedApiPath = BaseApiPath + "/getOrderStatusExtended.do";

            /// <summary>
            /// încasare plăți - pentru plăți prin 2-phase
            /// </summary>
            public const string BaseDepositApiPath = BaseApiPath + "/deposit.do";
            /// <summary>
            /// anulare preautorizare - pentru plăți prin 2-phase
            /// </summary>
            public const string BaseReverseApiPath = BaseApiPath + "/reverse.do";
            /// <summary>
            /// rambursare
            /// </summary>
            public const string BaseRefundApiPath = BaseApiPath + "/refund.do";
            /// <summary>
            /// plăți recurente
            /// </summary>
            public const string BaseRecurringPaymentApiPath = BaseApiPath + "/recurringPayment.do";

        }

        public static class Test
        {
            public const string BaseApiUrl = "https://ecclients-sandbox.btrl.ro";
            public const string BaseApiPath = BaseApiUrl + "/payment/rest";
            public const string BaseRegisterApiPath = BaseApiPath + "/register.do";
            public const string BaseRegisterPreAuthApiPath = BaseApiPath + "/registerPreAuth.do";
            public const string BaseGetOrderStatusApiPath = BaseApiPath + "/getOrderStatus.do";
            public const string BaseGetOrderStatusExtendedApiPath = BaseApiPath + "/getOrderStatusExtended.do";

            /// <summary>
            /// încasare plăți - pentru plăți prin 2-phase
            /// </summary>
            public const string BaseDepositApiPath = BaseApiPath + "/deposit.do";
            /// <summary>
            /// anulare preautorizare - pentru plăți prin 2-phase
            /// </summary>
            public const string BaseReverseApiPath = BaseApiPath + "/reverse.do";
            /// <summary>
            /// rambursare
            /// </summary>
            public const string BaseRefundApiPath = BaseApiPath + "/refund.do";
            /// <summary>
            /// plăți recurente
            /// </summary>
            public const string BaseRecurringPaymentApiPath = BaseApiPath + "/recurringPayment.do";
        }
    }
}
