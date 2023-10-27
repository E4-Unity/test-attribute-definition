using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class GearAttributeTest : AttributeTest<UGearAttribute>
{
	protected override void CheckAddCalculation(UGearAttribute total, IEnumerable<UGearAttribute> operands)
	{
		int attackCalculationResult = 0;
		int defenseCalculationResult = 0;

		// TODO 필요에 따라 계산식 수정
		foreach (var operand in operands)
		{
			attackCalculationResult = int.MaxValue - attackCalculationResult < operand.Attack
				? int.MaxValue
				: attackCalculationResult + operand.Attack;

			defenseCalculationResult = int.MaxValue - defenseCalculationResult < operand.Defense
				? int.MaxValue
				: defenseCalculationResult + operand.Defense;
		}

		attackCalculationResult = Mathf.Clamp(attackCalculationResult, 0, UGearAttribute.MaxAttack);
		defenseCalculationResult = Mathf.Clamp(defenseCalculationResult, 0, UGearAttribute.MaxDefense);

		Assert.AreEqual(attackCalculationResult, total.Attack, "Attack 계산 결과가 다릅니다");
		Assert.AreEqual(defenseCalculationResult, total.Defense, "Defense 계산 결과가 다릅니다");
	}

	protected override void CheckRemoveCalculation(UGearAttribute total, IEnumerable<UGearAttribute> operands)
	{
		int attackCalculationResult = 0;
		int defenseCalculationResult = 0;

		// TODO 필요에 따라 계산식 수정
		foreach (var operand in operands)
		{
			if (ReferenceEquals(operand, operands.First()))
			{
				attackCalculationResult = operand.Attack;
				defenseCalculationResult = operand.Defense;
			}
			else
			{
				// 오버플로우 검사
				attackCalculationResult = attackCalculationResult <= int.MinValue + operand.Attack
					? int.MinValue
					: attackCalculationResult - operand.Attack;

				defenseCalculationResult = defenseCalculationResult <= int.MinValue + operand.Defense
					? int.MinValue
					: defenseCalculationResult - operand.Defense;
			}
		}

		attackCalculationResult = Mathf.Clamp(attackCalculationResult, 0, UGearAttribute.MaxAttack);
		defenseCalculationResult = Mathf.Clamp(defenseCalculationResult, 0, UGearAttribute.MaxDefense);

		Assert.AreEqual(attackCalculationResult, total.Attack, "Attack 계산 결과가 다릅니다");
		Assert.AreEqual(defenseCalculationResult, total.Defense, "Defense 계산 결과가 다릅니다");
	}
}
