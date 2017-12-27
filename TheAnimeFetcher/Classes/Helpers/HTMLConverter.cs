using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.HTML;

namespace TheAnimeFetcher.Classes.Helpers
{
    public static class HTMLConverter
    {
        public static List<Anime> GetAnimeRecommendations(string HTMLAsString)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(HTMLAsString);
            string unfilteredjsonstring = doc.GetHtmlDocumentBody().GetChildNodeById("v-auto-recommendation-personalized_anime").GetCustomAttributeValue("data-initial-data");
            return new List<Anime>();
        }
        public static List<Manga> GetMangaRecommendations(string responseAsString)
        {
            throw new NotImplementedException();
        }

        private static HtmlNode GetHtmlDocumentBody(this HtmlDocument htmlDocument)
        {
            return htmlDocument.DocumentNode.SelectSingleNode("//body");
        }
        private static HtmlNode GetChildNodeById(this HtmlNode htmlNode, string Id)
        {
            return htmlNode.ChildNodes.Where(node => node.Id == Id).Single();
        }
        private static string GetCustomAttributeValue(this HtmlNode htmlNode, string CustomAttributeName)
        {
            string test = "";
            string test2 = "";
            HtmlAttribute attr = htmlNode.Attributes.AttributesWithName(CustomAttributeName).Single();
            test = attr.Value;
            test2 = attr.DeEntitizeValue;
            return test;    
        }
    }
}
