using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.JSON;

namespace TheAnimeFetcher.Classes.Services.Enumerations
{
    public enum HttpContentType
    {
        [Value("json/txt")]
        JSON,
        [Value("xml/txt")]
        XML,
        [Value("text/html")]
        HTML,
    }
    public enum UnofficialMALSearchType // TODO: Create better deserializable classes
    {
        [Value("all"), Type(typeof(Search))]
        All,
        [Value("manga"), Type(typeof(Search))]
        Manga,
        [Value("anime"), Type(typeof(Search))]
        Anime,
        [Value("character"), Type(typeof(Search))]
        Characters,
        [Value("person"), Type(typeof(Search))]
        People,
        [Value("news"), Type(typeof(Search))]
        News,
        [Value("featured"), Type(typeof(Search))]
        Featured_Articles,
        [Value("forum"), Type(typeof(Search))]
        Forum,
        [Value("club"), Type(typeof(Search))]
        Clubs,
        [Value("user"), Type(typeof(Search))]
        Users
    }
    public enum OfficialMALSearchType
    {
        [Value("anime"), Type(typeof(XML.Anime))]
        Anime,
        [Value("manga"), Type(typeof(XML.Manga))]
        Manga
    }
    public enum AnimeStatus
    {
        Finished_Airing,
        Currently_Airing,
        Not_yet_aired,
        Not_Specified // Custom type
    }
    public enum AnimeType
    {
        TV,
        OVA,
        Movie,
        Special,
        ONA,
        Music,
        Not_Specified // Custom type
    }
    public enum MangaStatus
    {
        Finished,
        Publishing,
        Not_yet_published,
        Not_Specified
    }
    public enum MangaType
    {
        Manga,
        Novel,
        One_shot,
        Doujinshi,
        Manhwa,
        Manhua,
        OEL,
        Not_Specified
    }
    public static class HttpContentTypeExtensions
    {
        public static string GetValue(this HttpContentType value)
        {
            return value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueAttribute>().Value;
        }
    }
    public static class UnofficialMALSearchTypeExtensions
    {
        public static string GetValue(this UnofficialMALSearchType value)
        {
            return value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueAttribute>().Value;
        }
        public static Type GetMALSearchType(this UnofficialMALSearchType type)
        {
            return type.GetType().GetField(type.ToString()).GetCustomAttribute<TypeAttribute>().Type;
        }
    }
    public static class OfficialMALSearchTypeExtensions
    {
        public static string GetValue(this OfficialMALSearchType value)
        {
            return value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueAttribute>().Value;
        }
        public static Type GetMALSearchType(this OfficialMALSearchType type)
        {
            return type.GetType().GetField(type.ToString()).GetCustomAttribute<TypeAttribute>().Type;
        }
    }
    public class ValueAttribute : Attribute
    {
        public string Value { get; private set; }

        public ValueAttribute(string Value)
        {
            this.Value = Value;
        }
    }
    public class TypeAttribute : Attribute
    {
        public Type Type { get; private set; }

        public TypeAttribute(Type Type)
        {
            this.Type = Type;
        }
    }
}
