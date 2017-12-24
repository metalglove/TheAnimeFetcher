using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.XML;

namespace TheAnimeFetcher.Classes.Services
{
    public static class MAL
    {
        #region Fields
        private const string MAL_API_URL = "https://myanimelist.net/api/";
        #endregion

        public static async Task<User> VerifyCredentials(NetworkCredential credentials)
        {
            HttpWebResponse response = null;
            User User = new User();
            try
            {
                response = await SendHttpGETRequest(credentials, "account/verify_credentials.xml");
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    User = XMLConverter.DeserializeXmlAsStringToClass<User>(responseStream.ReadToEnd());
                    User.Credentials = credentials;
                }
            }
            catch (WebException ex)
            {
                Debug.Write(ex.ToString());
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                }
            }

            return User;
        }
        private static bool EnsureStatusCode(HttpWebResponse response)
        {
            bool returnval = false;
            switch (response.StatusCode)
            {
                case HttpStatusCode.Accepted:
                    break;
                case HttpStatusCode.Ambiguous:
                    break;
                case HttpStatusCode.BadGateway:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                case HttpStatusCode.Conflict:
                    break;
                case HttpStatusCode.Continue:
                    break;
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.ExpectationFailed:
                    break;
                case HttpStatusCode.Forbidden:
                    break;
                case HttpStatusCode.Found:
                    break;
                case HttpStatusCode.GatewayTimeout:
                    break;
                case HttpStatusCode.Gone:
                    break;
                case HttpStatusCode.HttpVersionNotSupported:
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.LengthRequired:
                    break;
                case HttpStatusCode.MethodNotAllowed:
                    break;
                case HttpStatusCode.Moved:
                    break;
                case HttpStatusCode.NoContent:
                    returnval = true;
                    break;
                case HttpStatusCode.NonAuthoritativeInformation:
                    break;
                case HttpStatusCode.NotAcceptable:
                    break;
                case HttpStatusCode.NotFound:
                    break;
                case HttpStatusCode.NotImplemented:
                    break;
                case HttpStatusCode.NotModified:
                    break;
                case HttpStatusCode.OK:
                    returnval = true;
                    break;
                case HttpStatusCode.PartialContent:
                    break;
                case HttpStatusCode.PaymentRequired:
                    break;
                case HttpStatusCode.PreconditionFailed:
                    break;
                case HttpStatusCode.ProxyAuthenticationRequired:
                    break;
                case HttpStatusCode.RedirectKeepVerb:
                    break;
                case HttpStatusCode.RedirectMethod:
                    break;
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    break;
                case HttpStatusCode.RequestEntityTooLarge:
                    break;
                case HttpStatusCode.RequestTimeout:
                    break;
                case HttpStatusCode.RequestUriTooLong:
                    break;
                case HttpStatusCode.ResetContent:
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    break;
                case HttpStatusCode.SwitchingProtocols:
                    break;
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    break;
                case HttpStatusCode.Unused:
                    break;
                case HttpStatusCode.UpgradeRequired:
                    break;
                case HttpStatusCode.UseProxy:
                    break;
                default:
                    break;
            }
            return returnval;
        }
        private static async Task<HttpWebResponse> SendHttpGETRequest(NetworkCredential credentials, string requesteduri) => (await GetHttpWebRequest(credentials, requesteduri).GetResponseAsync()) as HttpWebResponse;
        private static HttpWebRequest GetHttpWebRequest(NetworkCredential credentials, string requesteduri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(MAL_API_URL + requesteduri);
            webRequest.ContentType = "xml/txt";
            webRequest.Credentials = credentials;
            return webRequest;
        }
    }
}
