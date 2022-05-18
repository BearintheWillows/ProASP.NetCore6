using SportsStore.Models;

namespace SportsStore.Interfaces;

public interface IStoreRepository
{
	IQueryable<Product> Products { get; }
}