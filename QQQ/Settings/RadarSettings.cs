using LogicLyrico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
namespace LogicLyric.Settings
{
    public class RadarSettings
    {

        public static bool showPlayer = false;
        public static bool showPlayerNickname = false;
        public static bool drawBigCircle = false;
        public static bool drawMiddleCircle = false;
        public static bool drawSmallerCircle = false;
        public static bool drawBigSquare = false;
        public static bool drawMiddleSquare = false;
        public static bool drawSquare = false;
        public static List<HarvestableType> harvestableTypes = new List<HarvestableType>();
        public static Dictionary<int,bool>  harvestingTiers = new Dictionary<int, bool>();
        public static Dictionary<int, bool> harvestingEnchants = new Dictionary<int, bool>();

        public static Dictionary<int, bool> mobsTiers = new Dictionary<int, bool>();


        public static Dictionary<int, bool> mobsType = new Dictionary<int, bool>();
        public static Dictionary<int, bool> mobsEnchant = new Dictionary<int, bool>();
        public static Dictionary<string, bool> chestEnchants = new Dictionary<string, bool>();



        public static Dictionary<int, bool> mistEnchant = new Dictionary<int, bool>();
        public static Dictionary<int, bool> mistType = new Dictionary<int, bool>();

        public static Dictionary<string, bool> mistBossesType = new Dictionary<string, bool>();

        public static Dictionary<int, bool> dungeonEnchant = new Dictionary<int, bool>();
        public static Dictionary<int, bool> dungeonType  = new Dictionary<int, bool>();


        public static bool isInMobsTiers(int tier)
        {
            if (mobsTiers.ContainsKey(tier))
            {
                return mobsTiers[tier];
            }
            return false;
        }

        public static bool isInMobTypes(int tier)
        {
            if (mobsType.ContainsKey(tier))
            {
                return mobsType[tier];
            }
            return false;
        }

        public static void updateMobTiers(int tier, bool show)
        {
            if (mobsTiers.ContainsKey(tier))
            {
                mobsTiers[tier] = show;
            }
            else
            {
                mobsTiers.Add(tier, show);
            }
        }

        public static void updateMobTypes(int tier, bool show)
        {
            if (mobsType.ContainsKey(tier))
            {
                mobsType[tier] = show;
            }
            else
            {
                mobsType.Add(tier, show);
            }
        }

        public static bool isInDungeonEnchant(int enchant)
        {
            if (dungeonEnchant.ContainsKey(enchant))
            {
                return dungeonEnchant[enchant];
            }
            return false;
        }


        public static void updateDungeonEnchant(int enchant, bool show)
        {
            if (dungeonEnchant.ContainsKey(enchant))
            {
                dungeonEnchant[enchant] = show;
            }
            else
            {
                dungeonEnchant.Add(enchant, show);
            }
        }


        public static bool isInDungeonType(int type)
        {
            if (dungeonType.ContainsKey(type))
            {
                return dungeonType[type];
            }
            return false;
        }


        public static void updateDungeonType(int type, bool show)
        {
            if (dungeonType.ContainsKey(type))
            {
                dungeonType[type] = show;
            }
            else
            {
                dungeonType.Add(type, show);
            }
        }








        public static bool isInMistEnchant(int enchant)
        {
            if (mistEnchant.ContainsKey(enchant))
            {
                return mistEnchant[enchant];
            }
            return false;
        }


        public static void updatemistEnchant(int enchant, bool show)
        {
            if (mistEnchant.ContainsKey(enchant))
            {
                mistEnchant[enchant] = show;
            }
            else
            {
                mistEnchant.Add(enchant, show);
            }
        }


        public static bool isInMistType(int type)
        {
            if (mistType.ContainsKey(type))
            {
                return mistType[type];
            }
            return false;
        }

        public static bool isInMistBossesType(string type)
        {

            foreach(KeyValuePair<string, bool> entry in mistBossesType)
            {
                
                if(type.ToLower().Contains(entry.Key.ToLower()))
                {
                    return entry.Value;

                }

            }
            return false;
        }


        public static void updateMistBosses(string type, bool show)
        {
            if (mistBossesType.ContainsKey(type))
            {
                mistBossesType[type] = show;
            }
            else
            {
                mistBossesType.Add(type, show);
            }
        }

        public static void updateMistType(int type, bool show)
        {
            if (mistType.ContainsKey(type))
            {
                mistType[type] = show;
            }
            else
            {
                mistType.Add(type, show);
            }
        }




        public static void updateHarvestingTier(int tier,  bool show)
        {
        
            
            if(harvestingTiers.ContainsKey(tier))
            {
                harvestingTiers[tier] = show;
            }
            else
                {
                harvestingTiers.Add(tier, show);
            }
        }
        public static void updateChestEnchants(string enchant, bool show)
        {
            if (chestEnchants.ContainsKey(enchant))
            {
                chestEnchants[enchant] = show;
            }
            else
            {
                chestEnchants.Add(enchant, show);
            }
        }

        public static bool isInChestsEnchant(string  enchant)
        {
            foreach (KeyValuePair<string, bool> entry in chestEnchants)
            {

                if (entry.Value)
                {
                    if (enchant.Contains(entry.Key))
                    {
                        return true;
                    }
                }


            }
            return false;
        }
        public static void updateMobEnchants(int enchant, bool show)
        {

            if (mobsEnchant.ContainsKey(enchant))
            {
                mobsEnchant[enchant] = show;
            }
            else
            {
                mobsEnchant.Add(enchant, show);
            }
        }
        public static bool isInMobEnchant(int enchant)
        {
            if (mobsEnchant.ContainsKey(enchant))
            {
                return mobsEnchant[enchant];
            }
            return false;
        }
        public static bool isInEnchants(int enchant)
        {
            if(harvestingEnchants.ContainsKey(enchant))
            {
                return harvestingEnchants[enchant];
            }
            return false;
        }

        public static bool isInTiers(int tier)
        {
            if (harvestingTiers.ContainsKey(tier))
            {
                return harvestingTiers[tier];
            }
            return false;
        }


        public static void updateHarvestingEnchant(int enchant, bool show)
        {

            if (harvestingEnchants.ContainsKey(enchant))
            {
                harvestingEnchants[enchant] = show;
            }
            else
            {
                harvestingEnchants.Add(enchant, show);
            }
        }

        public static bool isInHarvestable(HarvestableType harvestableType)
        {
            return harvestableTypes.Contains(harvestableType);
        }

        public static void updateHarvestableType(List<HarvestableType> harvestingType, bool show)
        {
            if (show)
            {
                foreach (HarvestableType harvestableType in harvestingType)
                {


                    if (!harvestableTypes.Contains(harvestableType))
                    {
                        harvestableTypes.Add(harvestableType);
                    }
                }
                
            }
            else
            {
                foreach (HarvestableType harvestableType in harvestingType)
                {


                    if (harvestableTypes.Contains(harvestableType))
                    {
                        harvestableTypes.Remove(harvestableType);
                    }
                }
            }
        }

    }
}
