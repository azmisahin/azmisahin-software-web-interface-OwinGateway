namespace OwinGate
{
    internal static class OwinConstants
    {
        #region General
        public const string Version = "owin.Version";
        public const string CallCancelled = "owin.CallCancelled";
        public const string TraceOutput = "host.TraceOutput";
        #endregion
        
        #region Request
        public const string RequestBody = "owin.RequestBody";
        public const string RequestHeaders = "owin.RequestHeaders";
        public const string RequestScheme = "owin.RequestScheme";
        public const string RequestMethod = "owin.RequestMethod";
        public const string RequestPathBase = "owin.RequestPathBase";
        public const string RequestPath = "owin.RequestPath";
        public const string RequestQueryString = "owin.RequestQueryString";
        public const string RequestProtocol = "owin.RequestProtocol";
        #endregion
        
        #region Response
        public const string ResponseStatusCode = "owin.ResponseStatusCode";
        public const string ResponseReasonPhrase = "owin.ResponseReasonPhrase";
        public const string ResponseHeaders = "owin.ResponseHeaders";
        public const string ResponseBody = "owin.ResponseBody";
        #endregion
        
        #region Server
        public const string RemoteIpAddress = "server.RemoteIpAddress";
        public const string RemotePort = "server.RemotePort";
        public const string LocalIpAddress = "server.LocalIpAddress";
        public const string LocalPort = "server.LocalPort";
        public const string OnSendingHeaders = "server.OnSendingHeaders";
        #endregion
    }
}
