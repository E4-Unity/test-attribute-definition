using System;
using UnityEngine;

[Serializable]
public class UWeaponAttribute : UAttributeBase
{
	/* 정적 필드 */
	public static int MaxBaseDamage = int.MaxValue;

	/* 필드 */
	[SerializeField] int _baseDamage;

	/* 프로퍼티 */
	public int BaseDamage
	{
		get => Mathf.Clamp(_baseDamage, 0, MaxBaseDamage);
		set => _baseDamage = Mathf.Clamp(value, 0, MaxBaseDamage);
	}

	/* 메서드 */
	public override bool Equals(object obj)
	{
		if (obj is not UWeaponAttribute other) return false;

		return BaseDamage == other.BaseDamage;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(BaseDamage);
	}

	protected override UAttributeBase Add(UAttributeBase other)
	{
		if (Clone() is not UWeaponAttribute result) return null;
		if (other is not UWeaponAttribute otherAttribute) return result;

		// 오버플로우 검사
		result.BaseDamage = int.MaxValue - result.BaseDamage <= otherAttribute.BaseDamage
			? int.MaxValue
			: result.BaseDamage + otherAttribute.BaseDamage;

		return result;
	}

	protected override UAttributeBase Remove(UAttributeBase other)
	{
		if (Clone() is not UWeaponAttribute result) return null;
		if (other is not UWeaponAttribute otherAttribute) return result;

		// 오버플로우 검사
		result.BaseDamage = result.BaseDamage <= int.MinValue + otherAttribute.BaseDamage
			? int.MinValue
			: result.BaseDamage - otherAttribute.BaseDamage;

		return result;
	}

	public override UAttributeBase Clone()
	{
		return new UWeaponAttribute
		{
			BaseDamage = BaseDamage
		};
	}

	public override UAttributeBase Random()
	{
		return new UWeaponAttribute
		{
			BaseDamage = UnityEngine.Random.Range(0, int.MaxValue)
		};
	}
}
