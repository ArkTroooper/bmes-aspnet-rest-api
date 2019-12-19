using System.Collections.Generic;
using BmesRestApi.Models.Order;

namespace BmesRestApi.Repositories
{
    public interface IOrderRepository
    {
        Order FindOrderById(long id);
        IEnumerable<Order> GetAllOrders();
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
