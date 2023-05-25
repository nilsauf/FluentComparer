namespace FluentComparer
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Extensions for a <see cref="IComparer{TObjectToCompare}"/> to add more Comparisons
	/// </summary>
	public static class FluentComparerExtensions
	{
		/// <summary>
		/// Extends a comparer to compare an additional property
		/// </summary>
		/// <typeparam name="TObjectToCompare">The type of the objects to compare</typeparam>
		/// <typeparam name="TProperty">The type of the property to compare</typeparam>
		/// <param name="previousComparer">The previous comparer to extend</param>
		/// <param name="getProperty">The function to retrieve the property</param>
		/// <returns>This comparer</returns>
		public static IComparer<TObjectToCompare> For<TObjectToCompare, TProperty>(
			this IComparer<TObjectToCompare> previousComparer,
			Func<TObjectToCompare, TProperty> getProperty)
			where TProperty : IComparable<TProperty>
		{
			if (getProperty is null)
			{
				throw new ArgumentNullException(nameof(getProperty));
			}

			return Comparer<TObjectToCompare>.Create(
				ComparisonCreator.GetCombinedComparison(previousComparer, getProperty));
		}
	}
}
