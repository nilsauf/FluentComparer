namespace FluentComparer
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// A static class to create a fluent object comparer
	/// </summary>
	public static class FluentComparer<TObjectToCompare>
	{
		/// <summary>
		/// Extends a comparer to compare an additional property
		/// </summary>
		/// <typeparam name="TProperty">The type of the property to compare</typeparam>
		/// <param name="getProperty">The function to retrieve the property</param>
		/// <returns>This comparer</returns>
		public static IComparer<TObjectToCompare> For<TProperty>(
			Func<TObjectToCompare, TProperty> getProperty)
			where TProperty : IComparable<TProperty>
		{
			if (getProperty is null)
			{
				throw new ArgumentNullException(nameof(getProperty));
			}

			return FluentComparerExtensions.For(null, getProperty);
		}
	}
}
