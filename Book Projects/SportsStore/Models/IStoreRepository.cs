namespace SportsStore.Models;

public interface IStoreRepository
{
	/// <summary>
	/// Allows Caller to obtain sequence of Product objects
	/// </summary>
	IQueryable<Product> Products { get; }
}