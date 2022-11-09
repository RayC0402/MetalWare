using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.Json;

namespace MetalWare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<itemType> list = new List<itemType>();
            XmlDocument xd = new XmlDocument();
            xd.Load("./ItemNewMetalWare.xml");
            XmlNodeList xnl = xd.SelectNodes(@"NewMetalWare/LevelDistributionList/LevelDistribution");
            foreach(XmlNode itemtypes in xnl)
            {
                var metalitemType = new itemType()
                {
                    ItemTypeId = Convert.ToInt32(itemtypes.Attributes["ItemTypeId"].Value),
                    RateRank3 = Convert.ToInt32(itemtypes.Attributes["RateRank3"].Value),
                    RateRank2 = Convert.ToInt32(itemtypes.Attributes["RateRank2"].Value),
                    RateRank1 = Convert.ToInt32(itemtypes.Attributes["RateRank1"].Value),
                    RateAbility1 = Convert.ToInt32(itemtypes.Attributes["RateAbility1"].Value),
                    RateAbility2 = Convert.ToInt32(itemtypes.Attributes["RateAbility2"].Value),
                    RateAbility3 = Convert.ToInt32(itemtypes.Attributes["RateAbility3"].Value),
                };
                list.Add(metalitemType);
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonType = JsonSerializer.Serialize(list, options);
            File.WriteAllText("./MetalWareItemType.txt", jsonType, Encoding.UTF8);
            Console.WriteLine("done");
        }
    }
}
