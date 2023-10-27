using UnityEngine;

public abstract class EntityDefinitionBase : ScriptableObject
{
	public abstract UAttributeBase Attribute { get; }
}

public class EntityDefinition<T> : EntityDefinitionBase where T : UAttributeBase
{
	[SerializeField] T _attribute;

	public override UAttributeBase Attribute => _attribute;
}
