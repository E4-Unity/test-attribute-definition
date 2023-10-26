using UnityEngine;

public abstract class EntityDefinitionBase : ScriptableObject
{
	public abstract UAttributeBase GetAttribute();
}

public class EntityDefinitionBase<T> : EntityDefinitionBase where T : UAttributeBase
{
	[SerializeField] T _attribute;
	public override UAttributeBase GetAttribute() => _attribute;
	public T Attribute => _attribute;
}
