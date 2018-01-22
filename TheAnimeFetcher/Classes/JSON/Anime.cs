using System;
using TheAnimeFetcher.Classes.Constants.Enumerations;

namespace TheAnimeFetcher.Classes.JSON
{
    public class Anime
    {
        private string _anime_image_path;
        private decimal _score;

        public int status { get; set; }
        public decimal score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                ScoreValue = ScoreValuesExtensions.DetermineScoreValue(_score);
            }
        }
        public ScoreValues ScoreValue { get; set; }
        public string ScoreValueAsString
        {
            get
            {
                return ScoreValue.GetValue();
            }
        }
        public string tags { get; set; }
        public int is_rewatching { get; set; }
        public int num_watched_episodes { get; set; }
        public string anime_title { get; set; }
        public int anime_num_episodes { get; set; }
        public int anime_airing_status { get; set; }
        public int anime_id { get; set; }
        public object anime_studios { get; set; }
        public object anime_licensors { get; set; }
        public object anime_season { get; set; }
        public bool has_episode_video { get; set; }
        public bool has_promotion_video { get; set; }
        public bool has_video { get; set; }
        public string video_url { get; set; }
        public string anime_url { get; set; }
        public string anime_image_path
        {
            get
            {
                return _anime_image_path;
            } 
            set
            {
                _anime_image_path = value;
                anime_image_pathHighRes = ConvertImagePathToHighRes(value);
            }
        }
        private string ConvertImagePathToHighRes(string value)
        {
            string mainpath = "https://myanimelist.cdn-dena.com/images/";
            string newvalue = value.Replace("https://myanimelist.cdn-dena.com/", "");
            int startIndex = newvalue.IndexOf("anime/");
            int endIndex = newvalue.IndexOf(".");
            return mainpath + newvalue.Substring(startIndex, endIndex - startIndex).Replace("//", "/") + ".jpg";
        }
        public string anime_image_pathHighRes { get; set; }
        public bool is_added_to_list { get; set; }
        public string anime_media_type_string { get; set; }
        public string anime_mpaa_rating_string { get; set; }
        public string start_date_string { get; set; }
        public string finish_date_string { get; set; }
        public string anime_start_date_string { get; set; }
        public string anime_end_date_string { get; set; }
        public int? days_string { get; set; }
        public string storage_string { get; set; }
        public string priority_string { get; set; }
    }
}