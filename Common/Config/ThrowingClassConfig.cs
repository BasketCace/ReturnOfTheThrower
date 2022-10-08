using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReturnOfTheThrower.Common.Config
{
    class ThrowingClassConfig : ModConfig
    {
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("Weapon Damage Conversions")] 
		[Label("Yoyo Conversion")]
		[Tooltip("Whether or not yoyos will deal throwing damage")] 
		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingYoyoToggle;

		[Label("Boomerang Conversion")]
		[Tooltip("Whether or not boomerang type weapons will deal throwing damage")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ThrowingBoomerangToggle;

		[Label("Dungeon Chest Item Conversion")]
		[Tooltip("Whether or not Vampire Knives and Scourge of the Corruptor will deal throwing damage")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ThrowingDungeonChestToggle;

		[Label("Zenith Conversion")]
		[Tooltip("Whether or not the Zenith deals throwing damage")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingZenithToggle;

		[Label("Daybreak Conversion")]
		[Tooltip("Whether or not the Daybreak deals throwing damage")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingDaybreakToggle;


		[Header("Armor Changes")]
		[Label("Fossil Armor")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingFossilArmor;

		[Label("Necro Armor")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingNecroArmor;

		[Label("Shinobi Infiltrator Armor")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ThrowingShinobiArmor;
	}
}
