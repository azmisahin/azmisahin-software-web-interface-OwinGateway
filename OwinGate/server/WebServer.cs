using System.Threading.Tasks;
using Microsoft.Owin;
namespace OwinGate
{
    public class WebServer
    {
        /// <summary>
        /// Web Server Async Start
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task Start(IOwinContext context)
        {
            #region Const
            string RequestPath = string.Empty;
            string data = string.Empty;
            string export = string.Empty;
            #endregion
            #region Request & Export
            RequestPath = (string)context.Environment["owin.RequestPath"];
            data = context.Request.Query["data"];
            export = Page.Welcome();
            #endregion
            #region Select and Get Content
            switch (RequestPath)
            {
                #region Roting
                case "/":
                    context.Response.ContentType = "text/html";
                    //export = Page.Offline();
                    export = Page.Welcome();
                    break;
                case "/Welcome":
                    context.Response.ContentType = "text/html";
                    export = Page.Welcome();
                    break;
                case "/Statics":
                    context.Response.ContentType = "text/html";
                    export = Page.Statics();
                    break;
                #endregion
                #region iati Gateway
                //Get
                case "/iati":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.test, data);
                    break;
                //Get
                case "/iati/airports":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.airports, data);
                    break;
                //Get
                case "/iati/currency":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.currency, data);
                    break;
                //Get [Special offers]
                case "/iati/spo":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.spo, data);
                    break;
                //?
                case "/iati/flightDetail":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.flightDetail, data);
                    break;

                //?
                case "/iati/providerRestrictions":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.providerRestrictions, data);
                    break;
                //Post
                case "/iati/flightSearch":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.flightSearch, data);
                    break;

                //Post
                case "/iati/fareRules":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.fareRules, data);
                    break;
                //Post
                case "/iati/isVoidable":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.isVoidable, data);
                    break;
                //Post
                case "/iati/makeReservation":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.makeReservation, data);
                    break;
                //Post
                case "/iati/makeTicket":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.makeTicket, data);
                    break;
                //Post
                case "/iati/makeTicketFromReservation":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.makeTicketFromReservation, data);
                    break;
                //Post
                case "/iati/priceDetail":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.priceDetail, data);
                    break;
                //Post
                case "/iati/voidPnr":
                    context.Response.ContentType = "application/json;charset=UTF-8";
                    export = Net.Send(iati.voidPnr, data);
                    break;
                    #endregion
            }
            #endregion
            return context.Response.WriteAsync(export);
        }
    }
}