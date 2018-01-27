using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.JSON;
using TheAnimeFetcher.Classes.Services;
using Windows.UI.Xaml.Controls;
using TheAnimeFetcher.Classes.Constants.Enumerations;
using TheAnimeFetcher.Classes.XML;

namespace TheAnimeFetcher.Classes.Controllers
{
    public class HomeController : ControllerBase
    {
        #region Delegates
        public delegate void delegateSetContentFrame(Frame contentFrame);
        public delegate void delegateContentFrameNavigate(Type type, object parameter);
        public static delegateSetContentFrame SetContentFrame = Navigator.SetContentFrame;
        public static delegateContentFrameNavigate ContentFrameNavigate = Navigator.ContentFrameNavigate;
        #endregion Delegates

        public static async Task<RecommendedList> GetRecommendationsFor(RecommendationsType RecommendationsType)
        {
            return await UnofficialMALAPI.GetRecommendations(RecommendationsType);
        }
        public static async Task<AnimeList> GetAnimeList()
        {
            if (UserData.AnimeList != null && UserData.AnimeListChanged == false)
            {
                return UserData.AnimeList;
            }
            else
            {
                UserData.AnimeList = await UnofficialMALAPI.GetAnimeList(UserData.User.Credentials, UserData.User.Username);
                UserData.AnimeListChanged = true;
                return UserData.AnimeList;
            }
        }
        public static async Task<MangaList> GetMangaList()
        {
            if (UserData.MangaList != null && UserData.MangaListChanged == false)
            {
                return UserData.MangaList;
            }
            else
            {
                UserData.MangaList = await UnofficialMALAPI.GetMangaList(UserData.User.Credentials, UserData.User.Username);
                UserData.MangaListChanged = true;
                return UserData.MangaList;
            }
        }
        public static async Task<XML.Anime> SearchAnime(string AnimeKeyword)
        {
            return await OfficialMALAPI.Search(AnimeKeyword, OfficialMALSearchType.Anime) as XML.Anime;
        }
        public static async Task<XML.Manga> SearchManga(string MangaKeyword)
        {
            return await OfficialMALAPI.Search(MangaKeyword, OfficialMALSearchType.Manga) as XML.Manga;
        }
        public static async Task<Search> SearchMAL(string Keyword, UnofficialMALSearchType SearchType = UnofficialMALSearchType.All)
        {
            return await UnofficialMALAPI.SearchMAL(Keyword, SearchType) as Search;
        }
        public static async Task<Recent> GetRecentsFor(RecentType RecentType)
        {
            return await UnofficialMALAPI.GetRecentsFor(RecentType, UserData.User.Username);
        }
        public static async Task<Recent> GetRecentsFor(RecentType RecentType, string Username)
        {
            return await UnofficialMALAPI.GetRecentsFor(RecentType, Username);
        }
    }
}
