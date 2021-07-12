using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace WebScraper
{
    class TXTGenerator
    {

        private List<URL> list;

        public TXTGenerator(List<URL> list)
        {

            this.list = list;

        }

        public void generateTXTFiles()
        {

            foreach (var url in list)
            {

                string fileName = url.getPosition().Trim().Replace("/", "-") + ".txt";

                StreamWriter sw = new StreamWriter(fileName);
                sw.Write(url.getContent());
                sw.Close();

            }

        }

    }
}