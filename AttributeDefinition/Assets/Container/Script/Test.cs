using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	[Header("Equipment")]
	[SerializeField] List<EntityDefinitionBase> _definitionList;

	[Header("Result")]
	[SerializeField] UWeaponAttribute _weaponAttribute;
	[SerializeField] UGearAttribute _gearAttribute;

	void OnValidate()
	{
		if (_definitionList.Count == 0)
		{
			_weaponAttribute = null;
			_gearAttribute = null;

			return;
		}

		var total = new AttributeContainer();
		foreach (var definition in _definitionList)
		{
			total.Add(definition.Attribute);
		}

		_weaponAttribute = total.GetAttribute<UWeaponAttribute>();
		_gearAttribute = total.GetAttribute<UGearAttribute>();

		float baseDamage = _weaponAttribute?.BaseDamage ?? 0;
		float attack = _gearAttribute?.Attack ?? 0;
		float damageRatio = (1 + attack / 100f); // Attack 10당 Damage 1% 증가

		float finalDamage = baseDamage * damageRatio;

		Debug.Log("Final Damage: " + baseDamage + " * " + damageRatio + " = " + finalDamage);
	}
}
