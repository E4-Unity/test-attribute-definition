using System.Collections.Generic;
using NUnit.Framework;

public abstract class AttributeTest<T> where T : UAttributeBase, new()
{
	[Test]
	public void Random()
	{
		var attribute = RandomAttribute();

		Assert.NotNull(attribute, "랜덤 생성 객체가 null입니다");
		Assert.AreEqual(typeof(T), attribute.GetType(), "랜덤 생성 객체의 타입이 올바르지 않습니다");

		for (int i = 0; i < 100; i++)
		{
			if (!IsOnlySameValue(attribute, attribute.Random())) return;
		}

		Assert.Fail("랜덤 테스트 100회를 통과하지 못하였습니다");
	}

	[Test]
	public void Clone()
	{
		var attribute = RandomAttribute();

		for (int i = 0; i < 10; i++)
		{
			var clone = attribute.Clone();
			CheckOnlyValueIsSame(attribute, clone);
		}
	}

	[Test]
	public void Add()
	{
		var attribute = new T();

		Assert.Null(attribute + null);
		Assert.Null(null + attribute);

		for (int i = 0; i < 100; i++)
		{
			var a = attribute.Random() as T;
			var b = attribute.Random() as T;
			var c = attribute.Random() as T;

			Assert.NotNull(a, "a is null");
			Assert.NotNull(b, "b is null");
			Assert.NotNull(c, "c is null");

			var total = (a + b + c) as T;

			Assert.NotNull(total, "total is null");

			if (ReferenceEquals(total, a) || ReferenceEquals(total, b) || ReferenceEquals(total, c))
				Assert.Fail("+ 연산자 결과물의 참조값이 피연산자들 중 하나와 일치합니다");

			CheckAddCalculation(total, new []{ a, b, c });
		}
	}

	protected abstract void CheckAddCalculation(T total, IEnumerable<T> operands);

	[Test]
	public void Remove()
	{
		var attribute = new T();

		Assert.Null(attribute - null);
		Assert.Null(null - attribute);

		for (int i = 0; i < 100; i++)
		{
			var a = attribute.Random() as T;
			var b = attribute.Random() as T;
			var c = attribute.Random() as T;

			Assert.NotNull(a, "a is null");
			Assert.NotNull(b, "b is null");
			Assert.NotNull(c, "c is null");

			var total = (a - b - c) as T;

			Assert.NotNull(total, "total is null");

			if (ReferenceEquals(total, a) || ReferenceEquals(total, b) || ReferenceEquals(total, c))
				Assert.Fail("+ 연산자 결과물의 참조값이 피연산자들 중 하나와 일치합니다");

			CheckRemoveCalculation(total, new []{ a, b, c });
		}
	}

	protected abstract void CheckRemoveCalculation(T total, IEnumerable<T> operands);

	UAttributeBase RandomAttribute() => new T().Random();

	bool IsOnlySameValue(UAttributeBase a, UAttributeBase b)
	{
		return !ReferenceEquals(a, b)
		       && a.Equals(b)
		       && a.GetHashCode() == b.GetHashCode();
	}

	void CheckOnlyValueIsSame(UAttributeBase a, UAttributeBase b)
	{
		Assert.False(ReferenceEquals(a, b), "Clone()의 대상과 결과물이 동일한 인스턴스입니다");
		Assert.True(a.Equals(b), "Clone()의 대상과 결과물의 값이 다릅니다");
		Assert.True(a.GetHashCode() == b.GetHashCode(), "Clone()의 대상과 결과물의 해시값이 다릅니다");
	}
}
