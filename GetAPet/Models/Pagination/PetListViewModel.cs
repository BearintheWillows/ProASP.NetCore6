namespace GetAPet.Models.Pagination;

public class PetListViewModel
{
	public IEnumerable<Pet> Pets { get; set; } = Enumerable.Empty<Pet>();
	
	public PagingInfo PagingInfo { get; set; } = new ();
}