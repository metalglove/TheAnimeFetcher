using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TheAnimeFetcher.Classes.Data;
using System.Net.Http;
using TheAnimeFetcher.Classes.Services.Enumerations;

namespace TheAnimeFetcher.Classes.Services
{
    public abstract class ServiceBase
    {
        // TODO: HttpClient HttpContentType checker
        #region HttpClient
        public static async Task<string> PostDataAsync(string url, FormUrlEncodedContent postData)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { CookieContainer = UserData.Instance.CookieContainer, AllowAutoRedirect = false });
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = postData;
            HttpResponseMessage response = await client.PostAsync(request.RequestUri, request.Content);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> GetDataAsync(string url, HttpContentType contentType = HttpContentType.JSON)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = UserData.Instance.CookieContainer, AllowAutoRedirect = false });
            return await httpClient.GetStringAsync(url);
        }
        public static async Task<string> GetDataAsync(string url, NetworkCredential credentials, HttpContentType contentType = HttpContentType.JSON)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = UserData.Instance.CookieContainer, AllowAutoRedirect = false, Credentials = credentials });
            return await httpClient.GetStringAsync(url);
        }
        #endregion

        #region WebClient
        protected static async Task<HttpWebResponse> SendHttpWebGETRequest(NetworkCredential credentials, string requesteduri, HttpContentType contentType)
        {
            HttpWebRequest request = GetHttpWebGetRequest(credentials, requesteduri, contentType);
            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
            return response;
        }
        private static HttpWebRequest GetHttpWebGetRequest(NetworkCredential credentials, string requesteduri, HttpContentType contentType)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requesteduri);
            webRequest.Method = "GET";
            webRequest.CookieContainer = UserData.Instance.CookieContainer;
            webRequest.ContentType = contentType.GetValue();
            webRequest.Credentials = credentials;
            return webRequest;
        }
        protected static bool EnsureStatusCode(HttpWebResponse response)
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
        #endregion WebClient
    }
}
