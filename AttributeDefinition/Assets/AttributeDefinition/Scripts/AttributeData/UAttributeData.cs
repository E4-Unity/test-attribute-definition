using System;

[Serializable]
public class UAttributeData
{
	public EntityDefinitionBase EntityDefinition;

	public UAttributeBase Attribute => EntityDefinition.GetAttribute();
}
