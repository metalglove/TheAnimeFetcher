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
using TheAnimeFetcher.Classes.JSON;
using TheAnimeFetcher.Classes.Constants.Enumerations;
using TheAnimeFetcher.Classes.XML;

namespace TheAnimeFetcher.Classes.Services
{
    public class UnofficialMALAPI : ServiceBase
    {
        #region Fields
        private const string MAL_URL = "https://myanimelist.net/";
        #endregion

        #region Token, Login And Placements
        private static async Task CheckForTokenAndPlacements()
        {
            if (UserData.Instance.CSRF_Token == null)
            {
                await GetToken();
                await Login();
                await GetPlacements();
            }
        }
        private static async Task GetToken()
        {
            string HTML = await GetDataAsync(MAL_URL + "Login.php", HttpContentType.HTML);
            HTMLConverter.ParseTokenFromHtml(HTML);
        }
        private static async Task Login()
        {
            string HTML = await PostDataAsync(MAL_URL + "Login.php", LoginPostData);
        }
        private static async Task GetPlacements()
        {
            string HTML = await GetDataAsync(MAL_URL, HttpContentType.HTML);
            HTMLConverter.ParsePlacementsFromHtml(HTML);
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

        public static async Task<RecommendedList> GetRecommendations(RecommendationsType recommendationsType)
        {
            await CheckForTokenAndPlacements();
            RecommendedList recommendations = new RecommendedList();
            HttpWebResponse response = null;
            try
            {
                response = await SendHttpWebGETRequest(UserData.Instance.User.Credentials, MAL_URL + "auto_recommendation/personalized_suggestions.json?placement=" + UserData.Instance.GetPlacementFor(recommendationsType), HttpContentType.JSON);
                if (EnsureStatusCode(response))
                {
                    StreamReader responseStream = new StreamReader(response.GetResponseStream());
                    string responseAsString = responseStream.ReadToEnd();
                    recommendations = JSONConverter.DeserializeJSon(responseAsString, recommendationsType.GetRecommendationsType()) as RecommendedList;
                    recommendations.RecommendationsType = recommendationsType;
                    recommendations.Where(recommended => recommended.Type != recommendationsType).Select(recommended => recommended.Type = recommendationsType);
                }
            }
            catch (Exception ex)
            {
                Debug.Write("GetRecommendations: Exception response: " + ex.Message);
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
                response = await SendHttpWebGETRequest(credentials, MAL_URL + "animelist/"+ Username + "/load.json", HttpContentType.JSON);
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
                response = await SendHttpWebGETRequest(credentials, MAL_URL + "mangalist/" + Username + "/load.json", HttpContentType.JSON);
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
        public static async Task<object> SearchMAL(string Keyword, UnofficialMALSearchType ContentType = UnofficialMALSearchType.All)
        {
            string TrimmedKeyword = Keyword.Trim();
            if (TrimmedKeyword.Length < 1)
            {
                return null;
            }
            object result = null;
            try
            {
                string resultAsString = await GetDataAsync(MAL_URL + "search/prefix.json?type=" + ContentType.GetValue() + "&keyword=" + TrimmedKeyword, HttpContentType.JSON);
                result = JSONConverter.DeserializeJSon(resultAsString, ContentType.GetUnofficialMALSearchType());
            }
            catch (Exception ex)
            {
                Debug.Write("SearchMAL: Exception value: " + ex.Message);
            }
            finally
            {
                if (result == null)
                {
                    throw new ArgumentException("SearchMAL: exception");
                }
            }
            return result;
        }
        public static async Task<Recent> GetRecentsFor(RecentType RecentType, string Username)
        {
            Rss Rss = null;
            try
            {
                string resultAsString = await GetDataAsync(MAL_URL + "rss.php?type=" + RecentType.GetValue() + "&u=" + Username, HttpContentType.XML);
                Rss = XMLConverter.DeserializeXmlAsStringToClass<Rss>(resultAsString);
            }
            catch (Exception ex)
            {
                Debug.Write("SearchMAL: Exception value: " + ex.Message);
            }
            finally
            {
                if (Rss == null)
                {
                    throw new ArgumentException("GetRecentsFor: exception");
                }
            }
            return Rss.Recent;
        }
    }
}
