using Store.Domain;
using Store_V2.Infastructure;
using Store_V2.Infastructure.Interfaces;


public class ProductService : IProductService
{
    private readonly Store_V2_DbContext _context;

    public ProductService(Store_V2_DbContext context)
    {
        _context = context;
    }

    public async Task<Products> GetProductAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }

    public async Task<bool> UpdateProductStockAsync(int productId, int quantity)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product == null || product.ProductStock < quantity) return false;

        product.ProductStock -= quantity;
        await _context.SaveChangesAsync();
        return true;
    }
}

