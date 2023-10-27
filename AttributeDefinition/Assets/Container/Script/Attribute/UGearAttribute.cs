using System;
using UnityEngine;

[Serializable]
public class UGearAttribute : UAttributeBase
{
	/* 정적 필드 */
	public static int MaxAttack = int.MaxValue;
	public static int MaxDefense = int.MaxValue;

	/* 필드 */
	[SerializeField] int _attack;
	[SerializeField] int _defense;

	public int Attack
	{
		get => Mathf.Clamp(_attack, 0, MaxAttack);
		set => _attack = Mathf.Clamp(value, 0, MaxAttack);
	}

	public int Defense
	{
		get => Mathf.Clamp(_defense, 0, MaxDefense);
		set => _defense = Mathf.Clamp(value, 0, MaxDefense);
	}

	public override bool Equals(object obj)
	{
		if (obj is not UGearAttribute other) return false;

		return Attack == other.Attack
		       && Defense == other.Defense;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Attack, Defense);
	}

	protected override UAttributeBase Add(UAttributeBase other)
	{
		if (Clone() is not UGearAttribute result) return null;
		if (other is not UGearAttribute otherAttribute) return result;

		// 오버플로우 검사
		result.Attack = int.MaxValue - result.Attack <= otherAttribute.Attack
			? int.MaxValue
			: result.Attack + otherAttribute.Attack;

		result.Defense = int.MaxValue - result.Defense <= otherAttribute.Defense
			? int.MaxValue
			: result.Defense + otherAttribute.Defense;

		return result;
	}

	protected override UAttributeBase Remove(UAttributeBase other)
	{
		if (Clone() is not UGearAttribute result) return null;
		if (other is not UGearAttribute otherAttribute) return result;

		// 오버플로우 검사
		result.Attack = result.Attack <= int.MinValue + otherAttribute.Attack
			? int.MinValue
			: result.Attack - otherAttribute.Attack;

		result.Defense = result.Defense <= int.MinValue + otherAttribute.Defense
			? int.MinValue
			: result.Defense - otherAttribute.Defense;

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

	public override UAttributeBase Random()
	{
		return new UGearAttribute
		{
			Attack = UnityEngine.Random.Range(0, int.MaxValue),
			Defense = UnityEngine.Random.Range(0, int.MaxValue)
		};
	}
}
