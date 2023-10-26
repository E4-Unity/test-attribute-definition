
public abstract class UAttributeBase
{
	public static UAttributeBase operator +(UAttributeBase left, UAttributeBase right)
	{
		return left.Add(right);
	}

	protected abstract UAttributeBase Add(UAttributeBase other);
}

public abstract class UAttributeBase<T> : UAttributeBase where T : UAttributeBase<T>
{
	public static T operator +(UAttributeBase<T> left, UAttributeBase right)
	{
		return ((UAttributeBase)left + right) as T;
	}
}
