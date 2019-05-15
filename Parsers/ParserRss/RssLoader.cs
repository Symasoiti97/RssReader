using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;

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

        public RssChannel ParseChannel(string link)
        {
            var rss = XDocument.Load(link);

            var ch = rss.Root?.Element("channel");

            var items = from i in rss.Descendants("item")
                        select new RssItem
                        {
                            Title =  i.Element("title").Value,
                            Content = i.Element("description").Value,
                            Link =  i.Element("link").Value,
                            PubTime = DateTime.Parse(i.Element("pubDate")?.Value)
                        };

            var channel = new RssChannel
            {
                Title = ch.Element("title")?.Value,
                Link = ch.Element("link")?.Value,
                RssItems = items.ToArray()
            };

            return channel;
        }
    }
}
