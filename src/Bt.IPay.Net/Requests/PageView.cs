using System.Runtime.Serialization;

namespace Bt.IPay.Net.Requests
{
    public enum PageView
    {
        /// <summary>
        /// pentru a încărca pagini pentru afișarea pe monitoarele PC (pagini cu nume de payment.html);
        /// </summary>
        [EnumMember(Value = "DESKTOP")]
        DESKTOP,
        //pentru a încărca pagini pentru afișarea pe dispozitive mobile (pagini cu nume mobile_payment.html);
        [EnumMember(Value = "MOBILE")]
        MOBILE
    }

    public static class PageViewExtensions 
    {
        public static string ToString(this PageView pageView)
        {
            return pageView == PageView.DESKTOP ? "DESKTOP" : "MOBILE";
        }
    }
}