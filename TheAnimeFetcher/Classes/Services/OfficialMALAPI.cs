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
    public class OfficialMALAPI : ServiceBase
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
                response = await SendHttpWebGETRequest(credentials, MAL_API_URL + "account/verify_credentials.xml", ContentType.XML);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    User = XMLConverter.DeserializeXmlAsStringToClass<User>(responseStream.ReadToEnd());
                    User.Credentials = credentials;
                }
            }
            catch (WebException ex)
            {
                Debug.Write("WebException response: " + ex.Status);
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
    }
}
