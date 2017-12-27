namespace TheAnimeFetcher.Classes.JSON
{
    public class Manga
    {
        public int id { get; set; }
        public int status { get; set; }
        public int score { get; set; }
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
        public string manga_image_path { get; set; }
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