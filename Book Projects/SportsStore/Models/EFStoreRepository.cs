namespace SportsStore.Models;

public class EFStoreRepository : IStoreRepository
{
    private readonly StoreDbContext _context;

    public EFStoreRepository( StoreDbContext ctx ) { _context = ctx; }

    #region IStoreRepository Members

    public IQueryable<Product> Products => _context.Products;

    #endregion
}