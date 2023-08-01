using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReturnOfTheThrower.Common.Config
{
    class ThrowingClassConfig : ModConfig
    {
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header($"ReturnOfTheThrower.ConfigHeader.WeaponConversion")] 

		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingYoyoToggle;


		[DefaultValue(true)]
		[ReloadRequired]
		public bool ThrowingBoomerangToggle;


		[DefaultValue(true)]
		[ReloadRequired]
		public bool ThrowingDungeonChestToggle;


		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingZenithToggle;


		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingDaybreakToggle;


		[Header($"ReturnOfTheThrower.ConfigHeader.ArmorConversion")]

		[DefaultValue(false)]
		[ReloadRequired]
		public bool ThrowingFossilArmor;

		[DefaultValue(true)]
		[ReloadRequired]
		public bool ThrowingShinobiArmor;
	}
}
