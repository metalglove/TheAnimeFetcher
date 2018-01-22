using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Data;

namespace TheAnimeFetcher.Classes.Helpers
{
    public static class HTMLConverter
    {
        public static void ParsePlacementsFromHtml(string HTMLAsString)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(HTMLAsString);
            string placement_manga = doc.GetElementbyId("v-auto-recommendation-personalized_manga").GetHtmlAttributeValue("data-placement");
            string placement_anime = doc.GetElementbyId("v-auto-recommendation-personalized_anime").GetHtmlAttributeValue("data-placement");
            if (placement_anime == "" && placement_manga == "")
            {
                throw new ArgumentException("Placements not found");
            }
            UserData.Instance.Placement_personalized_anime = placement_anime;
            UserData.Instance.Placement_personalized_manga = placement_manga;
        }
        public static void ParseTokenFromHtml(string HTMLAsString)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(HTMLAsString);
            string Token = doc.GetHtmlNodesMeta().GetChildNodeByName("csrf_token").GetHtmlAttributeValue("content");
            if (Token == "")
            {
                throw new ArgumentException("csrf_token was not found");
            }
            UserData.Instance.CSRF_Token = Token;
        }
        private static HtmlNodeCollection GetHtmlNodesMeta(this HtmlDocument htmlDocument)
        {
            return htmlDocument.DocumentNode.SelectNodes("//meta");
        }
        private static HtmlNode GetChildNodeByName(this HtmlNodeCollection htmlNodes, string Name)
        {
            foreach (HtmlNode node in htmlNodes)
            {
                foreach (HtmlAttribute attr in node.Attributes)
                {
                    if(attr.Value == Name)
                    {
                        return node;
                    }
                }
            }
            return null;
        }
        private static string GetHtmlAttributeValue(this HtmlNode htmlAttribute, string CustomAttributeName)
        {
           return htmlAttribute.Attributes.AttributesWithName(CustomAttributeName).Single().DeEntitizeValue;
        }
    }
}
