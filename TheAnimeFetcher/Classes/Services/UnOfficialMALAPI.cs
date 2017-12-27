using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Data;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.HTML;
using TheAnimeFetcher.Classes.JSON;

namespace TheAnimeFetcher.Classes.Services
{
    public class UnofficialMALAPI : ServiceBase
    {
        #region Fields
        private const string MAL_URL = "https://myanimelist.net/";
        #endregion

        #region Token
        private static async Task GetToken()
        {
            HTMLConverter.ParseTokenFromHtml(await GetDataAsync(MAL_URL + "Login.php"));
        }
        private static async Task CheckForToken()
        {
            if (UserData.Instance.CSRF_Token == null)
            {
                await GetToken();
                await Login();
            }
        }
        private static async Task Login()
        {
            string z = await PostDataAsync(MAL_URL + "Login.php", LoginPostData);
        }

        private static FormUrlEncodedContent LoginPostData
        {
            get
            {
                List<KeyValuePair<string, string>> LoginKeyValuePair = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("user_name", UserData.Instance.User.Credentials.UserName),
                    new KeyValuePair<string, string>("password", UserData.Instance.User.Credentials.Password),
                    new KeyValuePair<string, string>("sublogin", "Login"),
                    new KeyValuePair<string, string>("cookie", "1"),
                    new KeyValuePair<string, string>("submit", "1"),
                    new KeyValuePair<string, string>("csrf_token", UserData.Instance.CSRF_Token)
                };
                return new FormUrlEncodedContent(LoginKeyValuePair);
            }
        }
        #endregion

        public static async Task<Recommendations> GetRecommendations(NetworkCredential credentials)
        {
            await CheckForToken();
            Recommendations recommendations = new Recommendations();
            HttpWebResponse response = null;
            try
            {
                response = await SendHttpWebGETRequest(credentials, MAL_URL, ContentType.HTML);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    string responseAsString = responseStream.ReadToEnd();
                    recommendations.AnimeRecommendations = HTMLConverter.GetAnimeRecommendations(responseAsString);
                    recommendations.MangaRecommendations = HTMLConverter.GetMangaRecommendations(responseAsString);
                }
            }
            catch (WebException ex)
            {
                Debug.Write("GetRecommendations: WebException response: " + ex.Status);
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                }
            }
            return recommendations;
        }
        public static async Task<AnimeList> GetAnimeList(NetworkCredential credentials, string Username)
        {
            AnimeList animeList = new AnimeList();
            HttpWebResponse response = null;
            try
            {
                response = await SendHttpWebGETRequest(credentials, MAL_URL + "animelist/"+ Username + "/load.json", ContentType.JSON);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    string responseAsString = responseStream.ReadToEnd();
                    animeList = JSONConverter.DeserializeJSon<AnimeList>(responseAsString);
                }
            }
            catch (WebException ex)
            {
                Debug.Write("GetAnimeList: WebException response: " + ex.Status);
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                }
            }
            return animeList;
        }
        public static async Task<MangaList> GetMangaList(NetworkCredential credentials, string Username)
        {
            MangaList mangaList = new MangaList();
            HttpWebResponse response = null;
            try
            {
                response = await SendHttpWebGETRequest(credentials, MAL_URL + "mangalist/" + Username + "/load.json", ContentType.JSON);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    string responseAsString = responseStream.ReadToEnd();
                    mangaList = JSONConverter.DeserializeJSon<MangaList>(responseAsString);
                }
            }
            catch (WebException ex)
            {
                Debug.Write("GetMangaList: WebException response: " + ex.Status);
            }
            finally
            {
                if (response != null)
                {
                    response.Dispose();
                }
            }
            return mangaList;
        }
    }
}
