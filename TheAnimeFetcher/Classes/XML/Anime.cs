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
        private AnimeType _type;
        private string status;
        private AnimeStatus _status;
        private DateTime start_date;
        private string _start_date;
        private DateTime end_date;
        private string _end_date;

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
        public decimal Score { get; set; }
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
                _type = (AnimeType)Enum.Parse(typeof(AnimeType), value);
            }
        }
        public AnimeType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
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
                _status = (AnimeStatus)Enum.Parse(typeof(AnimeStatus), value.Replace(' ', '_'));
            }
        }
        public AnimeStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        [XmlElement(DataType = "date", ElementName = "start_date")] // TODO: Maybe also in DateTime format?
        private DateTime start_dateAsDateTime
        {
            get
            {
                return start_date;
            }
            set
            {
                start_date = value;
                _start_date = start_date.ToString("yyyy-MM-dd") == "0000-00-00" ? "Unknown" : start_date.ToString("yyyy-MM-dd");
            }
        }
        public string Start_date
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value;
            }
        }
        [XmlElement(DataType = "date", ElementName = "end_date")] // TODO: Maybe also in DateTime format?
        private DateTime end_dateAsDateTime
        {
            get
            {
                return end_date;
            }
            set
            {
                end_date = value;
                _end_date = end_date.ToString("yyyy-MM-dd") == "0000-00-00" ? "Unknown" : end_date.ToString("yyyy-MM-dd");
            }
        }
        public string End_date
        {
            get
            {
                return _end_date;
            }
            set
            {
                _end_date = value;
            }
        }
        [XmlElement(ElementName = "synopsis")] // TODO: Remove <br /> and insert new line?
        public string synopsis { get; set; }
        [XmlElement(ElementName = "image")] // TODO: Maybe also in Image format?
        public string Image_path { get; set; }
    }
}
