using HtmlAgilityPack;
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
using TheAnimeFetcher.Classes.Data;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.Services.Enumerations;
using TheAnimeFetcher.Classes.XML;
using TheAnimeFetcher.Classes.Services;

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
                response = await SendHttpWebGETRequest(credentials, MAL_API_URL + "account/verify_credentials.xml", HttpContentType.XML);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    User = XMLConverter.DeserializeXmlAsStringToClass<User>(responseStream.ReadToEnd());
                    User.Credentials = credentials;
                }
            }
            catch (WebException ex)
            {
                Debug.Write("VerifyCredentials:\nWebException response: " + ex.Status);
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
        public static async Task<object> Search(string Keyword, OfficialMALSearchType SearchType)
        {
            string TrimmedKeyword = Keyword.Trim();
            if (TrimmedKeyword.Length < 1)
            {
                return null;
            }
            object AnimeOrManga = new object();
            HttpWebResponse response = null;
            try
            {
                response = await SendHttpWebGETRequest(UserData.Instance.User.Credentials, MAL_API_URL + SearchType.GetValue() +"/search.xml?q=" + TrimmedKeyword, HttpContentType.XML);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    AnimeOrManga = XMLConverter.DeserializeXmlAsStringToClass(responseStream.ReadToEnd(), SearchType.GetMALSearchType());
                }
            }
            catch (WebException ex)
            {
                Debug.Write("Search:\nWebException response: " + ex.Status);
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                }
            }
            return AnimeOrManga;
        }
    }
}
