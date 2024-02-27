using CartApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApplication.Interfaces
{
    public interface ICartService
    {
        List<CartDTO> AddToCart(Guid userId, Guid productId);
        CartDTO GetCartItems(Guid userId);

        List<ProductsDTO> ViewCartDetails(Guid userId);
        List<OrderItemsDTO> ViewOrderItems(Guid userId);

        bool DeleteCartByUserId(Guid userId);
    }
}
