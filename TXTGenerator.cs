using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace WebScraper
{
    class TXTGenerator
    {

        private List<URL> list;
        private string Directory = "pozice/";

        public TXTGenerator(List<URL> list)
        {

            this.list = list;
            createDirectory();

        }
        
        private void createDirectory(){

            if(!System.IO.Directory.Exists(Directory)){
                System.IO.Directory.CreateDirectory(Directory);
            }
        }

        public void generateTXTFiles()
        {

            foreach (var url in list)
            {

                string fileName = url.getPosition().Trim().Replace("/", "-") + ".txt";

                StreamWriter sw = new StreamWriter(Directory+fileName);
                sw.Write(url.getContent());
                sw.Close();

                Console.WriteLine("[Task_"+list.IndexOf(url)+"] Writing file: " + Directory+fileName + "[COMPLETED]");

            }

        }

    }
}