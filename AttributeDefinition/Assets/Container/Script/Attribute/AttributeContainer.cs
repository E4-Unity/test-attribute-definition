using System;
using System.Collections.Generic;

public class AttributeContainer
{
	Dictionary<Type, List<UAttributeBase>> _container = new();
	Dictionary<Type, UAttributeBase> _cache = new();

	public static AttributeContainer operator +(AttributeContainer left, AttributeContainer right)
	{
		var result = new AttributeContainer();

		foreach (var pair in left._container)
		{
			result._container.Add(pair.Key, new List<UAttributeBase>());
			result._container[pair.Key].AddRange(pair.Value);
		}

		foreach (var pair in right._container)
		{
			if (!result._container.ContainsKey(pair.Key))
			{
				result._container.Add(pair.Key, new List<UAttributeBase>());
			}

			result._container[pair.Key].AddRange(pair.Value);
		}

		return result;
	}

	public void Add(UAttributeBase attribute)
	{
		var key = attribute.GetType();

		if (!_container.ContainsKey(key))
		{
			_container.Add(key, new List<UAttributeBase> { attribute });
			_cache.Add(key, attribute.Clone());
		}
		else
		{
			_container[key].Add(attribute);
			_cache[key] += attribute;
		}
	}

	public void Remove(UAttributeBase attribute)
	{
		var key = attribute.GetType();

		if (!_container.ContainsKey(key)) return;

		_container[key].Remove(attribute);
		_cache[key] -= attribute;

		if (_container[key].Count != 0) return;

		_container.Remove(key);
		_cache.Remove(key);
	}

	public T GetAttribute<T>() where T : UAttributeBase
	{
		return _cache.ContainsKey(typeof(T)) ? _cache[typeof(T)] as T : null;
	}
}
