using System;

[Serializable]
public class UGearAttribute : UAttributeBase<UGearAttribute>
{
	public int Attack;
	public int Defense;
	protected override UAttributeBase Add(UAttributeBase other)
	{
		if (other is UGearAttribute otherAttribute)
		{
			return new UGearAttribute()
			{
				Attack = Attack + otherAttribute.Attack,
				Defense = Defense + otherAttribute.Defense
			};
		}

		return new UGearAttribute()
		{
			Attack = Attack,
			Defense = Defense
		};
	}
}
