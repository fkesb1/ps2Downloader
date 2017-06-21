using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ps2DownloaderV2
{
    class findFile
    {
        public static string findsha(string name)
        {
            string data = "";
            data=parse1(name);
            if (data.Length == 0)
            {
                data = parse2(name);
            }
            return data;
        }
        private static string parse1(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Config.patchListUrl);
            XmlNodeList n = xmlDoc.GetElementsByTagName("folder");
            Console.WriteLine(n.Count);
            for(int i = 0; i < n.Count; i++)
            {
                try
                {
                    string type = n[i].Attributes["name"].Value;
                    if(type=="CommonData" || type=="Collision" || type == "Particles" || type=="Test" || type=="vehicles")
                    {
                        continue;
                    }
                    for(int j = 0; j < n[i].ChildNodes.Count; j++)
                    {
                        if(name== n[i].ChildNodes[j].Attributes["name"].Value)
                        {
                            return n[i].ChildNodes[j].Attributes["sha"].Value;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
            n= xmlDoc.GetElementsByTagName("file");
            for(int i = 0; i < n.Count; i++)
            {
                if (name == n[i].Attributes["name"].Value)
                {
                    return n[i].Attributes["sha"].Value;
                }
            }
            return "";
        }
        private static string parse2(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Config.patchListUrl2);
            XmlNodeList n = xmlDoc.GetElementsByTagName("folder");
            Console.WriteLine(n.Count);
            for (int i = 0; i < n.Count; i++)
            {
                try
                {
                    for (int j = 0; j < n[i].ChildNodes.Count; j++)
                    {
                        if (name == n[i].ChildNodes[j].Attributes["name"].Value)
                        {
                            return n[i].ChildNodes[j].Attributes["sha"].Value;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
            n = xmlDoc.GetElementsByTagName("file");
            for (int i = 0; i < n.Count; i++)
            {
                try
                {
                    if (name == n[i].Attributes["name"].Value)
                    {
                        return n[i].Attributes["sha"].Value;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return "";
        }
        public static string makeUrl(string sha,int server)
        {
            if (sha.Length <= 6) return "";
            string sha2 = sha.Substring(0,2);
            sha2 = sha2 + '/';
            sha2 = sha2+sha.Substring(2, 3);
            sha2 = sha2 + '/';
            sha2 = sha2+sha.Substring(5);
            switch (server)
            {
                case 1: sha2 = Config.server1 + '/' + sha2; break;
                case 2: sha2=Config.server2 + '/' + sha2; break;
                case 3: sha2=Config.server3 + '/' + sha2; break;
                case 4: sha2=Config.server4 + '/' + sha2; break;
                default: sha2=Config.server1 + '/' + sha2; break;
            }
            return sha2;
        }
    }
}
