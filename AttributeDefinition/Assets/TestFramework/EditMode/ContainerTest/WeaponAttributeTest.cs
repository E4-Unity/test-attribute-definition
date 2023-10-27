using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class WeaponAttributeTest : AttributeTest<UWeaponAttribute>
{
	protected override void CheckAddCalculation(UWeaponAttribute total, IEnumerable<UWeaponAttribute> operands)
	{
		int baseDamageCalculationResult = 0;

		// TODO 필요에 따라 계산식 수정
		foreach (var operand in operands)
		{
			// 오버플로우 검사
			baseDamageCalculationResult = int.MaxValue - baseDamageCalculationResult < operand.BaseDamage
				? int.MaxValue
				: baseDamageCalculationResult + operand.BaseDamage;
		}

		baseDamageCalculationResult = Mathf.Clamp(baseDamageCalculationResult, 0, UWeaponAttribute.MaxBaseDamage);
		Assert.AreEqual(baseDamageCalculationResult, total.BaseDamage, "BaseDamage 계산 결과가 다릅니다");
	}

	protected override void CheckRemoveCalculation(UWeaponAttribute total, IEnumerable<UWeaponAttribute> operands)
	{
		int baseDamageCalculationResult = 0;

		// TODO 필요에 따라 계산식 수정
		foreach (var operand in operands)
		{
			if (ReferenceEquals(operand, operands.First()))
			{
				baseDamageCalculationResult = operand.BaseDamage;
			}
			else
			{
				// 오버플로우 검사
				baseDamageCalculationResult = baseDamageCalculationResult <= int.MinValue + operand.BaseDamage
					? int.MinValue
					: baseDamageCalculationResult - operand.BaseDamage;
			}
		}

		baseDamageCalculationResult = Mathf.Clamp(baseDamageCalculationResult, 0, UWeaponAttribute.MaxBaseDamage);
		Assert.AreEqual(baseDamageCalculationResult, total.BaseDamage, "BaseDamage 계산 결과가 다릅니다");
	}
}
