using Store.Domain;

namespace Store_V2.Infastructure.Interfaces
{
    public interface IOrderService
    {
        Task<Orders> CreateOrderAsync(int customerId);
        Task<bool> FinalizeOrderAsync(int orderId);
    }
}
