using System;

namespace WebScraper
{

    class URL
    {

        private string url;
        private string position;
        private string content;

        public URL()
        {

        }

        public void setURL(string url)
        {

            this.url = url;

        }

        public void setPosiiton(string position)
        {

            this.position = position;

        }

        public void setContent(string content)
        {

            this.content = content;

        }

        public string getURL()
        {

            return this.url;
        }

        public string getPosition()
        {

            return this.position;
        }

        public string getContent()
        {

            return this.content;
        }

    }

}