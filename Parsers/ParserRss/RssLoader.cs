using DataBase.Models;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Parsers.ParserRss
{
    public class RssLoader
    {
        public static RssChannel ParserRss(string url)
        {
            RssChannel rssChanel = new RssChannel();
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed rss = SyndicationFeed.Load(reader);
            
            reader.Close();

            rssChanel.Title = rss.Title.Text;
            rssChanel.Link = rss.Links.ToString();
            rssChanel.RssItems = new List<RssItem>();

            foreach (var item in rss.Items)
            {
                rssChanel.RssItems.Add(new RssItem()
                {
                    Author = item.Authors.ToString(),
                    Category = item.Categories.ToString(),
                    Content = item.Summary.Text,
                    Link = item.Links.ToString(),
                    PubTime = item.PublishDate.UtcDateTime,
                    Title = item.Title.Text
                });
            }

            return rssChanel;
        }
    }
}
