using System.Threading.Tasks;
using Bt.IPay.Net.Constants;
using Bt.IPay.Net.Internal;
using Bt.IPay.Net.Reqursts;
using Bt.IPay.Net.Responses;
using Bt.IPay.Net.Responses.GetOrderStatusExtended;

namespace Bt.IPay.Net
{
    /// <summary>
    /// iPay BT - Banca Transilvania
    /// Mai multe detalii: https://btepos.ro/documentatie
    /// by Sibies Soft
    /// </summary>
    public class IpayClient: FormDataHttpClient
    {
        private readonly string _username;
        private readonly string _password;

        public static bool Debug = true;

        /// <summary>
        /// Credențialele de acces sunt perechi de tipul nume de utilizator și parolă și sunt furnizate de către Banca Transilvania în momentul creării comerciantului pe platforma iPay. Acestea sunt necesare pentru accesarea consolei iPay și pentru apelarea API-urilor.
        /// Atentie! Credențialele de producție nu funcționează pe mediul de test sau vice-versa.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public IpayClient(string username, string password)
            :this(username,password,true)
        {
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Credențialele de acces sunt perechi de tipul nume de utilizator și parolă și sunt furnizate de către Banca Transilvania în momentul creării comerciantului pe platforma iPay. Acestea sunt necesare pentru accesarea consolei iPay și pentru apelarea API-urilor.
        /// Atentie! Credențialele de producție nu funcționează pe mediul de test sau vice-versa.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="debugMode"></param>
        public IpayClient(string username, string password, bool debugMode)
        {
            _username = username;
            _password = password;
            Debug = debugMode;
        }

        /// <summary>
        /// 1-phase se pretează serviciilor gen asigurări, bilete/abonamente, unde “deposit” se realizează în mod automat pentru tranzacțiile finalizate cu succes. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<RegisterResponse> Register(RequestBase data)
        {
            data.UserName = _username;
            data.Password = _password;

            var response = await PostAsync<RequestBase, RegisterResponse>(
                Debug ? ApiConsts.Test.BaseRegisterApiPath : ApiConsts.Production.BaseRegisterApiPath, data);
            return response;
        }

        /// <summary>
        /// 2-phase se pretează serviciilor de bunuri care necesită livrare, unde întâi se blochează suma, iar la livrarea/confirmarea livrării bunurilor este necesar să realizați “completarea” tranzacției și trebuie generat “deposit”.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<RegisterResponse> RegisterPreAuth(RequestBase data)
        {
            data.UserName = _username;
            data.Password = _password;

            var response = await PostAsync<RequestBase, RegisterResponse>(
                Debug ? ApiConsts.Test.BaseRegisterPreAuthApiPath : ApiConsts.Production.BaseRegisterPreAuthApiPath,
                data);
            return response;
        }

        /// <summary>
        /// Verifica statusul unei plati
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<GetOrderStatusExtendedResponse> GetOrderStatusExtended(RequestBase data)
        {
            data.UserName = _username;
            data.Password = _password;

            var response = await PostAsync<RequestBase, GetOrderStatusExtendedResponse>(
                Debug
                    ? ApiConsts.Test.BaseGetOrderStatusExtendedApiPath
                    : ApiConsts.Production.BaseGetOrderStatusExtendedApiPath, data);
            return response;
        }

    }
}
