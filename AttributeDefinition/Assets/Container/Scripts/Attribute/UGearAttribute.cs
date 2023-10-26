using System;

[Serializable]
public class UGearAttribute : UAttributeBase
{
	public int Attack;
	public int Defense;

	protected override UAttributeBase Add(UAttributeBase other)
	{
		if (Clone() is not UGearAttribute result) return null;
		if (other is not UGearAttribute otherAttribute) return result;

		result.Attack += otherAttribute.Attack;
		result.Defense += otherAttribute.Defense;

		return result;
	}

	protected override UAttributeBase Remove(UAttributeBase other)
	{
		if (Clone() is not UGearAttribute result) return null;
		if (other is not UGearAttribute otherAttribute) return result;

		result.Attack -= otherAttribute.Attack;
		result.Defense -= otherAttribute.Defense;

		return result;
	}

	public override UAttributeBase Clone()
	{
		return new UGearAttribute
		{
			Attack = Attack,
			Defense = Defense
		};
	}
}
