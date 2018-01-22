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
        private MangaType _type;
        private string status;
        private MangaStatus _status;
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
        [XmlElement(ElementName = "chapters")]
        public int Chapters { get; set; }
        [XmlElement(ElementName = "volumes")]
        public int Volumes { get; set; }
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
                _type = (MangaType)Enum.Parse(typeof(MangaType), value.Replace('-', '_'));
            }
        }
        public MangaType Type
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
                _status = (MangaStatus)Enum.Parse(typeof(MangaStatus), value.Replace(' ', '_'));
            }
        }
        public MangaStatus Status
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