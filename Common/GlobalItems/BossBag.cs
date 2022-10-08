using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ReturnOfTheThrower.Content.Items.Accessories;
using Terraria.GameContent.ItemDropRules;
using System.Linq;

namespace ReturnOfTheThrower.Common.GlobalItems
{
    internal class BossBag : GlobalItem
    {
        //public override void OpenVanillaBag(string context, Player player, int arg)
        //{
        //    var source = player.GetSource_OpenItem(arg);
        //    if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag)
        //    {
        //        if (Main.rand.NextBool(5))
        //        {
        //            player.QuickSpawnItem(source, ModContent.ItemType<ThrowingEmblem>());
        //            NPCLoader.blockLoot.Add(ItemID.RangerEmblem);
        //            NPCLoader.blockLoot.Add(ItemID.RangerEmblem);
        //            NPCLoader.blockLoot.Add(ItemID.SorcererEmblem);
        //            NPCLoader.blockLoot.Add(ItemID.SummonerEmblem);
        //        }
                
        //    }
        //}

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            var entries = itemLoot.Get(false);
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                foreach (var entry in entries)
                {
                    if (entry is LeadingConditionRule leadingRule)
                    {
                        foreach (var chainedRule in entry.ChainedRules)
                        {
                            if (chainedRule.RuleToChain is OneFromOptionsNotScaledWithLuckDropRule oneFromOptionsRule)
                            {
                                var tempList = oneFromOptionsRule.dropIds.ToList();
                                if (tempList.Contains(ItemID.WarriorEmblem))
                                {
                                    int itemTypeToAdd = ModContent.ItemType<ThrowingEmblem>();
                                    if (!tempList.Contains(itemTypeToAdd))
                                    {
                                        tempList.Add(itemTypeToAdd);
                                    }
                                    oneFromOptionsRule.dropIds = tempList.ToArray();
                                }
                                /*
                                if (tempList.Contains(ItemID.BreakerBlade))
                                {
                                    int itemTypeToAdd = ModContent.ItemType<ThrowingEmblem>();
                                    if (!tempList.Contains(itemTypeToAdd))
                                    {
                                        tempList.Add(itemTypeToAdd);
                                    }
                                    oneFromOptionsRule.dropIds = tempList.ToArray();
                                }
                                */
                            }
                        }
                    }
                }

            }
        }
    }
}
