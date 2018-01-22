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
    public enum ScoreValues
    {
        [Value("Masterpiece")]
        Masterpiece = 10,
        [Value("Great")]
        Great = 9,
        [Value("Very Good")]
        Very_Good = 8,
        [Value("Good")]
        Good = 7,
        [Value("Fine")]
        Fine = 6,
        [Value("Average")]
        Average = 5,
        [Value("Bad")]
        Bad = 4,
        [Value("Very Bad")]
        Very_Bad = 3,
        [Value("Horrible")]
        Horrible = 2,
        [Value("Appalling")]
        Appalling = 1,
        [Value("Not Specified")]
        Not_Specified = 0
    }
    public static class ScoreValuesExtensions
    {
        public static string GetValue(this ScoreValues value)
        {
            return value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueAttribute>().Value;
        }
        public static ScoreValues DetermineScoreValue(decimal Score)
        {
            if (Score >= 0.50M && Score <= 1.49M)
            {
                return ScoreValues.Appalling;
            }
            else if (Score >= 1.50M && Score <= 2.49M)
            {
                return ScoreValues.Horrible;
            }
            else if (Score >= 2.50M && Score <= 3.49M)
            {
                return ScoreValues.Very_Bad;
            }
            else if (Score >= 3.50M && Score <= 4.49M)
            {
                return ScoreValues.Bad;
            }
            else if (Score >= 4.50M && Score <= 5.49M)
            {
                return ScoreValues.Average;
            }
            else if (Score >= 5.50M && Score <= 6.49M)
            {
                return ScoreValues.Fine;
            }
            else if (Score >= 6.50M && Score <= 7.49M)
            {
                return ScoreValues.Good;
            }
            else if (Score >= 7.50M && Score <= 8.49M)
            {
                return ScoreValues.Very_Good;
            }
            else if (Score >= 8.50M && Score <= 9.49M)
            {
                return ScoreValues.Great;
            }
            else if (Score >= 9.50M && Score <= 10M)
            {
                return ScoreValues.Masterpiece;
            }
            else
            {
                return ScoreValues.Not_Specified;
            }
        }
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
