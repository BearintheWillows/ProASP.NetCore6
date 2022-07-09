namespace GetAPet.Models.Repository;

using Models;

public interface IAppRepository
{
	IQueryable<Pet> Pets { get; }
}