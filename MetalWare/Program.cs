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
            List<EquipFilterList> list2 = new List<EquipFilterList>();
            List<AbilityList> list3 = new List<AbilityList>();
            XmlDocument xd = new XmlDocument();
            xd.Load("./ItemNewMetalWare.xml");
            XmlNodeList xnl = xd.SelectNodes(@"NewMetalWare/ItemTypeList/ItemType");
            XmlNodeList xnl2 = xd.SelectNodes(@"NewMetalWare/EquipFilterList/EquipFilter");
            XmlNodeList xnl3 = xd.SelectNodes(@"NewMetalWare/AbilityList/Ability");
            foreach (XmlNode itemtypes in xnl)
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
            foreach (XmlNode FilterList in xnl2)
            {
                var id = Convert.ToInt32(FilterList.Attributes["EquipFilterId"].Value);

                var filter = new EquipFilterList();
                filter.EquipFilterId = id;
                try
                {
                    filter.FilterName = FilterList.Attributes["FilterName"].Value;
                    filter.AllowString = FilterList.Attributes["AllowString"].Value;
                    filter.BlockString = FilterList.Attributes["BlockString"].Value;
                }
                catch { }
                list2.Add(filter);
            }
            foreach(XmlNode Ability in xnl3)
            {
                var id = Convert.ToInt32(Ability.Attributes["AbilityId"].Value);

                var abilityList = new AbilityList();
                abilityList.AbilityId = id;
                try
                {
                    abilityList.AbilityType = Ability.Attributes["AbilityType"].Value;
                    abilityList.AbilityCode = Ability.Attributes["AbilityCode"].Value;
                    abilityList.BaseMaxLevel = Convert.ToInt32(Ability.Attributes["BaseMaxLevel"].Value);
                    abilityList.BaseMaxLevelAcc = Convert.ToInt32(Ability.Attributes["BaseMaxLevelAcc"].Value);
                    abilityList.BaseMaxLevelOH = Convert.ToInt32(Ability.Attributes["BaseMaxLevelOH"].Value);
                    abilityList.InitialValue = Convert.ToSingle(Ability.Attributes["InitialValue"].Value);
                    abilityList.ValuePerLevel = Convert.ToSingle(Ability.Attributes["ValuePerLevel"].Value);
                    abilityList.BaseRate = Convert.ToInt32(Ability.Attributes["BaseRate"].Value);
                    abilityList.LimitBreak = Convert.ToBoolean(Ability.Attributes["LimitBreak"].Value);
                    abilityList.Standard = Convert.ToInt32(Ability.Attributes["Standard"].Value);
                    abilityList.IsFloat = Convert.ToBoolean(Ability.Attributes["IsFloat"].Value);
                    abilityList.Type1 = Convert.ToBoolean(Ability.Attributes["Type1"].Value);
                    abilityList.Type2 = Convert.ToBoolean(Ability.Attributes["Type2"].Value);
                    abilityList.Type3 = Convert.ToBoolean(Ability.Attributes["Type3"].Value);
                    abilityList.Type4 = Convert.ToBoolean(Ability.Attributes["Type4"].Value);
                    abilityList.Human = Convert.ToBoolean(Ability.Attributes["Human"].Value);
                    abilityList.Elf = Convert.ToBoolean(Ability.Attributes["Elf"].Value);
                    abilityList.Giant = Convert.ToBoolean(Ability.Attributes["Giant"].Value);
                    abilityList.OHSword = Convert.ToBoolean(Ability.Attributes["OHSword"].Value);
                    abilityList.THSword = Convert.ToBoolean(Ability.Attributes["THSword"].Value);
                    abilityList.OHAxe = Convert.ToBoolean(Ability.Attributes["OHAxe"].Value);
                    abilityList.THAxeGFS = Convert.ToBoolean(Ability.Attributes["THAxeGFS"].Value);
                    abilityList.OHBlunt = Convert.ToBoolean(Ability.Attributes["OHBlunt"].Value);
                    abilityList.THBlunt = Convert.ToBoolean(Ability.Attributes["THBlunt"].Value);
                    abilityList.THBluntGFS = Convert.ToBoolean(Ability.Attributes["THBluntGFS"].Value);
                    abilityList.TriboltWand = Convert.ToBoolean(Ability.Attributes["TriboltWand"].Value);
                    abilityList.LightningWand = Convert.ToBoolean(Ability.Attributes["LightningWand"].Value);
                    abilityList.IceWand = Convert.ToBoolean(Ability.Attributes["IceWand"].Value);
                    abilityList.FireWand = Convert.ToBoolean(Ability.Attributes["FireWand"].Value);
                    abilityList.HealingWand = Convert.ToBoolean(Ability.Attributes["HealingWand"].Value);
                    abilityList.Cylinder = Convert.ToBoolean(Ability.Attributes["Cylinder"].Value);
                    abilityList.CylinderTurret = Convert.ToBoolean(Ability.Attributes["CylinderTurret"].Value);
                    abilityList.Knuckle = Convert.ToBoolean(Ability.Attributes["Knuckle"].Value);
                    abilityList.HeavyArmor = Convert.ToBoolean(Ability.Attributes["HeavyArmor"].Value);
                    abilityList.Helm = Convert.ToBoolean(Ability.Attributes["Helm"].Value);
                    abilityList.Gauntlet = Convert.ToBoolean(Ability.Attributes["Gauntlet"].Value);
                    abilityList.Armorboots = Convert.ToBoolean(Ability.Attributes["Armorboots"].Value);
                    abilityList.Shield = Convert.ToBoolean(Ability.Attributes["Shield"].Value);
                    abilityList.Lightarmor = Convert.ToBoolean(Ability.Attributes["Lightarmor"].Value);
                    abilityList.Headgear = Convert.ToBoolean(Ability.Attributes["Headgear"].Value);
                    abilityList.Glove = Convert.ToBoolean(Ability.Attributes["Glove"].Value);
                    abilityList.Shoes = Convert.ToBoolean(Ability.Attributes["Shoes"].Value);
                    abilityList.ClothArmor = Convert.ToBoolean(Ability.Attributes["ClothArmor"].Value);
                    abilityList.ClothArmorComm = Convert.ToBoolean(Ability.Attributes["ClothArmorComm"].Value);
                    abilityList.Accessary = Convert.ToBoolean(Ability.Attributes["Accessary"].Value);
                    abilityList.Trainingbarton = Convert.ToBoolean(Ability.Attributes["Trainingbarton"].Value);
                    abilityList.CollectingTool = Convert.ToBoolean(Ability.Attributes["CollectingTool"].Value);
                    abilityList.Sieve = Convert.ToBoolean(Ability.Attributes["Sieve"].Value);
                    abilityList.SilkProductionTool = Convert.ToBoolean(Ability.Attributes["SilkProductionTool"].Value);
                    abilityList.BlacksmithHammer = Convert.ToBoolean(Ability.Attributes["BlacksmithHammer"].Value);
                    abilityList.Fishing = Convert.ToBoolean(Ability.Attributes["Fishing"].Value);
                    abilityList.Cooking = Convert.ToBoolean(Ability.Attributes["Cooking"].Value);
                    abilityList.HandcraftKit = Convert.ToBoolean(Ability.Attributes["HandcraftKit"].Value);
                    abilityList.CarpentryKit = Convert.ToBoolean(Ability.Attributes["CarpentryKit"].Value);
                    abilityList.Lumber = Convert.ToBoolean(Ability.Attributes["Lumber"].Value);
                    abilityList.InstrumentLure = Convert.ToBoolean(Ability.Attributes["InstrumentLure"].Value);
                    abilityList.Instrument = Convert.ToBoolean(Ability.Attributes["Instrument"].Value);
                    abilityList.MagicAssistanceBook = Convert.ToBoolean(Ability.Attributes["MagicAssistanceBook"].Value);
                    abilityList.LRod = Convert.ToBoolean(Ability.Attributes["LRod"].Value);
                    abilityList.HidePalm = Convert.ToBoolean(Ability.Attributes["HidePalm"].Value);
                    abilityList.TailorKit = Convert.ToBoolean(Ability.Attributes["TailorKit"].Value);
                    abilityList.MeleeWand = Convert.ToBoolean(Ability.Attributes["MeleeWand"].Value);
                    abilityList.Handle = Convert.ToBoolean(Ability.Attributes["Handle"].Value);
                    abilityList.Dualgun = Convert.ToBoolean(Ability.Attributes["Dualgun"].Value);
                    abilityList.Shuriken = Convert.ToBoolean(Ability.Attributes["Shuriken"].Value);
                    abilityList.DNDreamcatcher = Convert.ToBoolean(Ability.Attributes["DNDreamcatcher"].Value);
                    abilityList.Chainblade = Convert.ToBoolean(Ability.Attributes["Chainblade"].Value);
                    abilityList.Fynnbell = Convert.ToBoolean(Ability.Attributes["Fynnbell"].Value);
                    abilityList.Bow = Convert.ToBoolean(Ability.Attributes["Bow"].Value);
                    abilityList.Crossbow = Convert.ToBoolean(Ability.Attributes["Crossbow"].Value);
                    abilityList.Atlatl = Convert.ToBoolean(Ability.Attributes["Atlatl"].Value);
                    abilityList.Lance = Convert.ToBoolean(Ability.Attributes["Lance"].Value);
                    abilityList.SunRodColt = Convert.ToBoolean(Ability.Attributes["SunRodColt"].Value);
                    abilityList.MagicalKnuckle = Convert.ToBoolean(Ability.Attributes["MagicalKnuckle"].Value);
                    abilityList.RoughTouch = Convert.ToBoolean(Ability.Attributes["RoughTouch"].Value);
                    abilityList.Rapier = Convert.ToBoolean(Ability.Attributes["Rapier"].Value);
                    abilityList.Scythe = Convert.ToBoolean(Ability.Attributes["Scythe"].Value);
                }
                catch { }
                list3.Add(abilityList);
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonType = JsonSerializer.Serialize(list, options);
            string jsonfiler = JsonSerializer.Serialize(list2, options);
            string jsonaability = JsonSerializer.Serialize(list3, options);
            jsonfiler = jsonfiler.Replace("\\u0026", "&");
            
            File.WriteAllText("./MetalWareItemType.txt", jsonType, Encoding.UTF8);
            File.WriteAllText("./MetalWareItemfiler.txt", jsonfiler, Encoding.UTF8);
            File.WriteAllText("./MetalWareItemAbilityList.txt", jsonaability, Encoding.UTF8);
            Console.WriteLine("done");
        }
    }
}
