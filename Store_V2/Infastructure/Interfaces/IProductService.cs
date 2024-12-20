using Store.Domain;

namespace Store_V2.Infastructure.Interfaces
{
    public interface IProductService
    {
        Task<Products> GetProductAsync(int productId);
        Task<bool> UpdateProductStockAsync(int productId, int quantity);
    }

}
