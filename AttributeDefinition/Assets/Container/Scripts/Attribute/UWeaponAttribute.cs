using System;

[Serializable]
public class UWeaponAttribute : UAttributeBase
{
	public int BaseDamage;

	protected override UAttributeBase Add(UAttributeBase other)
	{
		if (Clone() is not UWeaponAttribute result) return null;
		if (other is not UWeaponAttribute otherAttribute) return result;

		result.BaseDamage += otherAttribute.BaseDamage;

		return result;
	}

	protected override UAttributeBase Remove(UAttributeBase other)
	{
		if (Clone() is not UWeaponAttribute result) return null;
		if (other is not UWeaponAttribute otherAttribute) return result;

		result.BaseDamage -= otherAttribute.BaseDamage;

		return result;
	}

	public override UAttributeBase Clone()
	{
		return new UWeaponAttribute
		{
			BaseDamage = BaseDamage
		};
	}
}
