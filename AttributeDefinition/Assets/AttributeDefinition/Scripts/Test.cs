using UnityEngine;

public class Test : MonoBehaviour
{
	public UAttributeData Sword; // 5
	public UAttributeData Ring; // 10, 10,
	public UAttributeData Belt; // 20, 20

	[Header("Sword + Sword")]
	[SerializeReference] UAttributeBase _result_1;

	[Header("Ring + Belt")]
	[SerializeReference] UAttributeBase _result_2;

	[Header("Sword + Ring")]
	[SerializeReference] UAttributeBase _result_3;

	[Header("Ring + Sword")]
	[SerializeReference] UAttributeBase _result_4;

	void OnValidate()
	{
		if (Sword.EntityDefinition is null || Ring.EntityDefinition is null || Belt.EntityDefinition is null)
		{
			_result_1 = null;
			_result_2 = null;
			_result_3 = null;
			_result_4 = null;

			return;
		}

		_result_1 = Sword.Attribute + Sword.Attribute; // 10
		_result_2 = Ring.Attribute + Belt.Attribute; // 30, 30
		_result_3 = Sword.Attribute + Ring.Attribute; // 5
		_result_4 = Ring.Attribute + Sword.Attribute; // 10, 10
	}
}
