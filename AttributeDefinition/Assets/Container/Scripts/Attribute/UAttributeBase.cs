/// <summary>
/// 데이터 클래스
/// 동일한 Attribute에 대한 연산 구현
/// 스탯 특성에 따라 적절한 연산(+, *, ..)을 수행하거나 최대 수치를 정하는 등의 작업을 할 수 있다
/// </summary>
public abstract class UAttributeBase
{
	public static UAttributeBase operator +(UAttributeBase left, UAttributeBase right) => left.Add(right);
	public static UAttributeBase operator -(UAttributeBase left, UAttributeBase right) => left.Remove(right);

	protected abstract UAttributeBase Add(UAttributeBase other);
	protected abstract UAttributeBase Remove(UAttributeBase other);

	public abstract UAttributeBase Clone();
}
