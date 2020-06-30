namespace Bt.IPay.Net.Constants
{
    public static class ApiConsts
    {
        public const string Version = "1.0.0";

        public static class Production
        {
            public const string BaseApiUrl = "https://ecclients.btrl.ro";
            public const string BaseApiPath = BaseApiUrl + "/payment/rest";
            public const string BaseRegisterApiPath = BaseApiPath + "/register.do";
            public const string BaseRegisterPreAuthApiPath = BaseApiPath + "/registerPreAuth.do";
            public const string BaseGetOrderStatusApiPath = BaseApiPath + "/getOrderStatus.do";
            public const string BaseGetOrderStatusExtendedApiPath = BaseApiPath + "/getOrderStatusExtended.do";
        }

        public static class Test
        {
            public const string BaseApiUrl = "https://ecclients.btrl.ro:5443";
            public const string BaseApiPath = BaseApiUrl + "/payment/rest";
            public const string BaseRegisterApiPath = BaseApiPath + "/register.do";
            public const string BaseRegisterPreAuthApiPath = BaseApiPath + "/registerPreAuth.do";
            public const string BaseGetOrderStatusApiPath = BaseApiPath + "/getOrderStatus.do";
            public const string BaseGetOrderStatusExtendedApiPath = BaseApiPath + "/getOrderStatusExtended.do";
        }
    }
}
