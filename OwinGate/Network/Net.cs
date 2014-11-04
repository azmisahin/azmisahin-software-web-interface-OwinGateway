using System;
using Microsoft.Owin;
using System.Net;
using System.IO;
namespace OwinGate
{
    public class Net
    {
        /// <summary>
        /// Context Base Trancast Request to Response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string Transact(IOwinContext context,string uri)
        {
            string result = string.Empty;
            try
            {
                WebRequest _WebRequest = WebRequest.Create(uri);
                _WebRequest.Method = context.Request.Method;
                _WebRequest.Headers.Clear();
                _WebRequest.ContentType = "application/json;charset=UTF-8";
                foreach (string HeaderKey in context.Request.Headers.Keys)
                {
                    try { _WebRequest.Headers.Set(HeaderKey, context.Request.Headers[HeaderKey]); }
                    catch (Exception) { }
                }
                using (WebResponse _WebResponse = _WebRequest.GetResponse())
                {
                    Stream _ResponseStream = _WebResponse.GetResponseStream();
                    _ResponseStream = _WebResponse.GetResponseStream();
                    StreamReader reader = new StreamReader(_ResponseStream);
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// Only Request uri base Post data
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Send(string uri, string data="")
        {
            string result=string.Empty;
            try
            {
                #region Socket Connector
                WebClient _WebClient = new WebClient();
                _WebClient.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
                #endregion
                #region Data Controller
                if (string.IsNullOrEmpty(data))
                {
                    #region Get Request
                    try
                    {
                        result = _WebClient.UploadString(uri, "GET");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        result = "Hatalı İstek" + Environment.NewLine +
                            "uri   : " + uri + Environment.NewLine +
                            "data  : " + data + Environment.NewLine +
                            "mesaj : " + ex.Message;
                    }
                    #endregion
                }
                else
                {
                    #region Post
                    try
                    {
                        result = _WebClient.UploadString(uri, "POST", data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        result = "Hatalı Talep" + Environment.NewLine +
                            "uri   : " + uri + Environment.NewLine +
                            "data  : " + data + Environment.NewLine +
                            "mesaj : " + ex.Message;
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                #region Cominicaton Error
                result = "Bağlantı Hatası" + Environment.NewLine +
                    "uri   : " + uri + Environment.NewLine +
                    "data  : " + data + Environment.NewLine +
                    "mesaj : " + ex.Message;
                #endregion
            }

            return result;
        }
    }
}