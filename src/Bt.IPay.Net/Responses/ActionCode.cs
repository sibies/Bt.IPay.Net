namespace Bt.IPay.Net.Responses
{
    public enum ActionCode
    {
        /// <summary>
        /// Tranzactie cu succes
        /// </summary>
        Succes = 0,
        
        /// <summary>
        /// Card inactiv. Vă rugăm activați cardul.
        /// </summary>
        CardInactiv = 320,
        
        /// <summary>
        /// Emitent indisponibil
        /// </summary>
        EmitentIndosponibil = 801,
        
        /// <summary>
        /// Card blocat. Vă rugăm contactați banca emitentă.
        /// </summary>
        CardBlocat = 803,
        
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
        /// Card expirat.
        /// </summary>
        CardGresit = 906,
        
        /// <summary>
        /// Cont invalid. Vă rugăm contactați banca emitentă.
        /// </summary>
        ContInvalid = 914,
        
        /// <summary>
        /// Fonduri insuficiente.
        /// </summary>
        FonduriInsuficiente = 915,
        
        /// <summary>
        /// Limită tranzacționare depășită.
        /// </summary>
        LimitaTranzactieDepasita = 917,
    }
}
