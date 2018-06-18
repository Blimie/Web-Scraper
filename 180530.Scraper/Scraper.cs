using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _180530.Scraper
{
    public class LakewoodScoopScraper
    {
        public IEnumerable<Post> GetPosts()
        {
            string url = $"http://www.thelakewoodscoop.com/";
            var client = new WebClient();
            var html = client.DownloadString(url);
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            IEnumerable<IElement> posts = document.QuerySelectorAll("div.post");
            return posts.Select(ParsePost);
        }

        private Post ParsePost(IElement post)
        {
            var a = post.QuerySelector("h2").QuerySelector("a");
            return new Post
            {
                Title = a.TextContent,
                Url = a.Attributes["href"].Value,
                ImageUrl = post.QuerySelector("p").QuerySelector("img").Attributes["src"].Value,
                Time = post.QuerySelector("small").TextContent,
                Text = post.QuerySelector("p").TextContent.Replace("Read more ›", "")
            };   
        }

    }
}
