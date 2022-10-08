using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using ReturnOfTheThrower.Content.Items.Accessories;
using ReturnOfTheThrower.Content.Items.Weapons;

namespace ReturnOfTheThrower.Common.GlobalNPCs
{
    internal class BossDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.WallofFlesh)
            {

                var entries = npcLoot.Get(false);
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
            if (npc.type == NPCID.Pumpking)
            {
                var entries = npcLoot.Get(false);
                foreach (var entry in entries)
                {
                    if (entry is LeadingConditionRule leadingRule)
                    {
                        foreach (var chainedRule in entry.ChainedRules)
                        {
                            if (chainedRule.RuleToChain is OneFromRulesRule oneFromRulesRule)
                            {
                                var tempList = oneFromRulesRule.options.ToList();
                                foreach (var rule in tempList)
                                {
                                    if (rule is CommonDrop normalDropRule && normalDropRule.itemId == ItemID.TheHorsemansBlade)
                                    {
                                        IItemDropRule ruleToAdd = ItemDropRule.Common(ModContent.ItemType<Batarang>());
                                        tempList.Add(ruleToAdd);
                                        oneFromRulesRule.options = tempList.ToArray(); 
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
