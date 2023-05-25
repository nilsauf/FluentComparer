namespace FluentComparer
{
	using System;
	using System.Collections.Generic;

	internal static class ComparisonCreator
	{
		public static Comparison<TObjectToCompare> GetCombinedComparison<TObjectToCompare, TProperty>(
			IComparer<TObjectToCompare> previousComparer,
			Func<TObjectToCompare, TProperty> getProperty)
			where TProperty : IComparable<TProperty>
		{
			Comparison<TObjectToCompare> additionalComparison = GetComparison(getProperty);

			return (first, second) =>
			{
				int comparisonResult = previousComparer?.Compare(first, second) ?? 0;
				return comparisonResult == 0 ?
					additionalComparison(first, second) :
					comparisonResult;
			};
		}

		public static Comparison<TObjectToCompare> GetComparison<TObjectToCompare, TProperty>(
			Func<TObjectToCompare, TProperty> getProperty)
			where TProperty : IComparable<TProperty>
		{
			return (first, second) =>
			{
				if (CompareForNull(first, second, out int comparisonResult))
				{
					return comparisonResult;
				}

				var firstProp = getProperty(first);
				var secondProp = getProperty(second);

				if (CompareForNull(firstProp, secondProp, out comparisonResult))
				{
					return comparisonResult;
				}

				return firstProp.CompareTo(secondProp);
			};
		}

		public static bool CompareForNull<T>(T first, T second, out int comparisonResult)
		{
			comparisonResult = 0;

			if (first == null && second == null)
			{
				return true;
			}

			if (first == null && second != null)
			{
				comparisonResult = -1;
				return true;
			}

			if (first != null && second == null)
			{
				comparisonResult = 1;
				return true;
			}

			return false;
		}
	}
}
