using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Services.Enumerations;

namespace TheAnimeFetcher.Classes.JSON
{
    public class Search
    {
        public List<Category> categories { get; set; }
    }
    public class Category
    {
        public string type { get; set; }
        public List<Item> items { get; set; }
    }
    public class Item
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string thumbnail_url { get; set; }
        public Payload payload { get; set; }
        public float es_score { get; set; }
    }
    // TODO: Make Payloads Unique for each Category
    public class Payload
    {
        private decimal _score;

        public string media_type { get; set; }
        public int start_year { get; set; }
        public string aired { get; set; }
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
        public string status { get; set; }
        public string published { get; set; }
        public List<string> related_works { get; set; }
        public int favorites { get; set; }
        public string alternative_name { get; set; }
        public string birthday { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public string work_title { get; set; }
        public int members { get; set; }
        public string created_by { get; set; }
        public string authority { get; set; }
        public string joined { get; set; }
    }
}
