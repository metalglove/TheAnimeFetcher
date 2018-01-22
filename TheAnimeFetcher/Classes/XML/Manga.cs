using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;
using TheAnimeFetcher.Classes.Services.Enumerations;

namespace TheAnimeFetcher.Classes.XML
{
    [XmlRoot(ElementName = "manga")]
    public class Manga
    {
        [XmlElement(ElementName = "entry")]
        public List<MangaEntry> Entries { get; set; }
    }
    public class MangaEntry
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
        [XmlElement(ElementName = "chapters")]
        public int Chapters { get; set; }
        [XmlElement(ElementName = "volumes")]
        public int Volumes { get; set; }
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
                Type = (MangaType)Enum.Parse(typeof(MangaType), value.Replace('-', '_'));
            }
        }
        [XmlIgnore]
        public MangaType Type { get; set; }
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
                Status = (MangaStatus)Enum.Parse(typeof(MangaStatus), value.Replace(' ', '_'));
            }
        }
        [XmlIgnore]
        public MangaStatus Status { get; set; }
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