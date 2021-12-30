using System.Collections.Generic;
using System.Linq;
using Bt.IPay.Net.Requests;

namespace Bt.IPay.Net.Extensions
{
    public static class RegisterRequestExtensions
    {
        public const string Force3Ds2Key = "FORCE_3DS2";
        public const string Force3Ds2DefaultValue = "true";

        public static void Force3dSe(this RegisterRequest request)
        {
            if (request == null) return;
            if (request.JsonParams != null && request.JsonParams.Any())
            {
                if (!request.JsonParams.ContainsKey(Force3Ds2Key))
                {
                    request.JsonParams.Add(Force3Ds2Key, Force3Ds2DefaultValue);
                }
            }
            else
            {
                request.JsonParams = new Dictionary<string, string> { { Force3Ds2Key, Force3Ds2DefaultValue } };
            }
        }

        public static Dictionary<string, string> Force3dSe(this Dictionary<string, string> jsonParams)
        {
            if (jsonParams != null && jsonParams.Any())
            {
                if (!jsonParams.ContainsKey(Force3Ds2Key))
                {
                    jsonParams.Add(Force3Ds2Key, Force3Ds2DefaultValue);
                }
            }
            else
            {
                jsonParams = new Dictionary<string, string> { { Force3Ds2Key, Force3Ds2DefaultValue } };
            }

            return jsonParams;
        }
    }
}