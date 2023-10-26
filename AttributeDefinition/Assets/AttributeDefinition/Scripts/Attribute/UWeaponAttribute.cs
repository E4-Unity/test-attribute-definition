using System;

[Serializable]
public class UWeaponAttribute : UAttributeBase<UWeaponAttribute>
{
	public int BaseDamage;

	protected override UAttributeBase Add(UAttributeBase other)
	{
		if (other is UWeaponAttribute otherAttribute)
		{
			return new UWeaponAttribute()
			{
				BaseDamage = BaseDamage + otherAttribute.BaseDamage,
			};
		}

		return new UWeaponAttribute()
		{
			BaseDamage = BaseDamage
		};
	}
}
