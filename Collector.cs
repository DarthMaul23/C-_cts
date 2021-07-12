using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using HtmlAgilityPack;

namespace WebScraper
{

    class Collector
    {

        private string url;

        private List<URL> urls = new List<URL>();

        private HtmlWeb web = new HtmlWeb();

        private HtmlDocument html;

        public Collector(string url)
        {

            this.url = url;
            html = web.Load(getUrl());

            analyze();

        }

        public string getUrl()
        {

            return this.url;
        }

        private void analyze()
        {

            prepareLinks();

            setData();

            TXTGenerator txtGenerator = new TXTGenerator(this.urls);
            txtGenerator.generateTXTFiles();

        }

        private void prepareLinks()
        {

            var pozice = html.DocumentNode.SelectNodes("//div[@class='col']/a");

            foreach (HtmlNode item in pozice)
            {

                urls.Add(new URL());

                string url_1 = getUrl().Remove(getUrl().Length - 9) + "" + item.Attributes["href"].Value;
                urls[urls.Count - 1].setURL(url_1);

            }

        }

        private void setData()
        {

            foreach (var item in urls)
            {

                string section = "Co Tě u nás čeká";

                html = web.Load(item.getURL());

                var pozice = html.DocumentNode.SelectSingleNode("//div[@class='container-8']").InnerText.Trim();

                var content = html.DocumentNode.SelectSingleNode("//div[@class='container-9 mb-md-5']");

                string content1 = content.InnerText.Trim();

                content1 = content1.Remove(0, content1.IndexOf(section) + section.Length);

                item.setPosiiton(pozice);

                item.setContent(content1);

            }

        }

    }
}