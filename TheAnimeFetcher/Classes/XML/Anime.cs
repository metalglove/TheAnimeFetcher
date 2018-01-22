using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;
using TheAnimeFetcher.Classes.Services.Enumerations;

namespace TheAnimeFetcher.Classes.XML
{
    [XmlRoot(ElementName = "anime")]
    public class Anime
    {
        [XmlElement(ElementName = "entry")]
        public List<AnimeEntry> Entries { get; set; }
    }
    public class AnimeEntry
    {
        private string type;
        private string status;
        private decimal score;

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "english")]
        public string EnglishTitle { get; set; }
        [XmlElement(ElementName = "synonyms")]
        private string synonyms
        {
            set
            {
                Synonyms = value.Split(';').ToList();
            }
        } 
        public List<string> Synonyms { get; set; } = new List<string>();
        [XmlElement(ElementName = "episodes")]
        public int Episodes { get; set; }
        [XmlElement(ElementName = "score")]
        public decimal Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                ScoreValue = ScoreValuesExtensions.DetermineScoreValue(score);
            }
        }
        [XmlIgnore]
        public ScoreValues ScoreValue { get; set; }
        [XmlIgnore]
        public string ScoreValueAsString
        {
            get
            {
                return ScoreValue.GetValue();
            }
        }
        [XmlElement(ElementName = "type")]
        private string TypeAsString
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                Type = (AnimeType)Enum.Parse(typeof(AnimeType), value);
            }
        }
        [XmlIgnore]
        public AnimeType Type { get; set; }
        [XmlElement(ElementName = "status")]
        private string StatusAsString
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                Status = (AnimeStatus)Enum.Parse(typeof(AnimeStatus), value.Replace(' ', '_'));
            }
        }
        [XmlIgnore]
        public AnimeStatus Status { get; set; }
        [XmlIgnore]
        public DateTime? start_dateAsDateTime
        {
            get
            {
                DateTime dt;
                if (DateTime.TryParse(Start_date, out dt))
                {
                    return dt;
                }
                return null;
            }
            set
            {
                Start_date = value == null ? "Unknown" : value.Value.ToString("dd-MM-yyyy");
            }
        }
        [XmlElement(ElementName = "start_date")]
        public string Start_date { get; set; }
        [XmlIgnore]
        public DateTime? end_dateAsDateTime
        {
            get
            {
                DateTime dt;
                if (DateTime.TryParse(End_date, out dt))
                {
                    return dt;
                }
                return null;
            }
            set
            {
                End_date = value == null ? "Unknown" : value.Value.ToString("dd-MM-yyyy");
            }
        }
        [XmlElement(ElementName = "end_date")]
        public string End_date { get; set; }
        [XmlElement(ElementName = "synopsis")] // TODO: Remove <br /> and insert new line?
        public string synopsis { get; set; }
        [XmlElement(ElementName = "image")] // TODO: Maybe also in Image format?
        public string Image_path { get; set; }
    }
}
