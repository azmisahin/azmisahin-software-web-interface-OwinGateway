using System;
namespace OwinGate
{
    public class iati
    {
        #region Const
        private static bool ssl
        {
            get
            {
                return Convert.ToBoolean(Core.configiration.Get("ssl"));
            }
        }
        private static string protocol
        {
            get
            {
                return Core.configiration.Get("protocol");
            }
        }
        private static string domain
        {
            get
            {
                return Core.configiration.Get("domain");
            }
        }
        private static string token
        {
            get
            {
                return Core.configiration.Get("token");
            }
        }
        private static string provider
        {
            get
            {
                return Core.configiration.Get("provider");
            }
        }
        #region Reading Application Config
        public static string uri
        {
            get
            {
                return "" +
                    Core.configiration.Get("ssl") +
                    Core.configiration.Get("domain") +
                    Core.configiration.Get("token") +
                    Core.configiration.Get("provider") +
                    "";
            }
        }
        #endregion
        #endregion
        #region Proparties
        public static string airports
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.airports + token;
                return ret;
            }
        }
        public static string currency
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.currency + token;
                return ret;
            }
        }
        public static string fareRules
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.fareRules + token;
                return ret;
            }
        }
        public static string flightSearch
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.flightSearch + token;
                return ret;
            }
        }
        public static string flightDetail
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.flightDetail + token;
                return ret;
            }
        }
        public static string providerRestrictions
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.providerRestrictions + token;
                return ret;
            }
        }
        public static string spo
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.spo + token;
                return ret;
            }
        }
        public static string isVoidable
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.isVoidable + token;
                return ret;
            }
        }
        public static string makeReservation
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.makeReservation + token;
                return ret;
            }
        }
        public static string makeTicket
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.makeTicket + token;
                return ret;
            }
        }
        public static string makeTicketFromReservation
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.makeTicketFromReservation + token;
                return ret;
            }
        }
        public static string priceDetail
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.priceDetail + token;
                return ret;
            }
        }
        public static string voidPnr
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.voidPnr + token;
                return ret;
            }
        }
        public static string test
        {
            get
            {
                string ret = string.Empty;
                ret += protocol;
                ret += domain + servis.test + token;
                return ret;
            }
        }
        #endregion
        #region Servis Path
        internal class servis
        {
            internal static string airports = "/rest/airports/";
            internal static string currency = "/rest/common/currency/";
            internal static string fareRules = "/rest/fareRules/";
            internal static string flightSearch = "/rest/flightSearch/";
            internal static string flightDetail = "/rest/flight/detail/";
            //rest/flight/detail/{authCode}/{id}
            //rest/flight/detail/{authCode}/{id}/{currency}
            internal static string providerRestrictions = "/rest/flight/providerRestrictions/";
            //rest/flight/providerRestrictions/{authCode}/{providerKey}
            internal static string spo = "/rest/spo/";
            internal static string isVoidable = "/rest/isVoidable/";
            internal static string makeReservation = "/rest/makeReservation/";
            internal static string makeTicket = "/rest/makeTicket/";
            internal static string makeTicketFromReservation = "/rest/makeTicketFromReservation/";
            internal static string priceDetail = "/rest/priceDetail/";
            internal static string voidPnr = "/rest/voidPnr/";
            internal static string test = "/rest/test/sample/";
        }
        #endregion
    }
}