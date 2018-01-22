using Newtonsoft.Json;
using TheAnimeFetcher.Classes.Services.Enumerations;

namespace TheAnimeFetcher.Classes.JSON
{
    public class Manga
    {
        private string _manga_image_path;
        private decimal _score;

        public int id { get; set; }
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
        public int is_rereading { get; set; }
        public int num_read_chapters { get; set; }
        public int num_read_volumes { get; set; }
        public string manga_title { get; set; }
        public int manga_num_chapters { get; set; }
        public int manga_num_volumes { get; set; }
        public int manga_publishing_status { get; set; }
        public int manga_id { get; set; }
        public object manga_magazines { get; set; }
        public string manga_url { get; set; }
        public string manga_image_path
        {
            get
            {
                return _manga_image_path;
            }
            set
            {
                _manga_image_path = value;
                manga_image_pathHighRes = ConvertImagePathToHighRes(value);
            }
        }
        private string ConvertImagePathToHighRes(string value)
        {
            string mainpath = "https://myanimelist.cdn-dena.com/images/";
            string newvalue = value.Replace("https://myanimelist.cdn-dena.com/", "");
            int startIndex = newvalue.IndexOf("manga/");
            int endIndex = newvalue.IndexOf(".");
            return mainpath + newvalue.Substring(startIndex, endIndex - startIndex).Replace("//", "/") + ".jpg";
        }
        public string manga_image_pathHighRes { get; private set; }
        public bool is_added_to_list { get; set; }
        public string manga_media_type_string { get; set; }
        public object start_date_string { get; set; }
        public object finish_date_string { get; set; }
        public string manga_start_date_string { get; set; }
        public string manga_end_date_string { get; set; }
        public object days_string { get; set; }
        public object retail_string { get; set; }
        public string priority_string { get; set; }
    }
}