using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.HTML;
using TheAnimeFetcher.Classes.JSON;
using TheAnimeFetcher.Classes.Services;
using Windows.UI.Xaml.Controls;

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

        public static async Task<Recommendations> GetRecommendations()
        {
            return await UnofficialMALAPI.GetRecommendations(UserData.User.Credentials);
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
    }
}
