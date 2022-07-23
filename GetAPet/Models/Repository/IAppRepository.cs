namespace GetAPet.Models.Repository;

using Models;

public interface IAppRepository
{
	IQueryable<Pet> Pets { get; }
	
	void SavePet(Pet pet);
	void DeletePet(Pet pet);
	void CreatePet(Pet pet);
}