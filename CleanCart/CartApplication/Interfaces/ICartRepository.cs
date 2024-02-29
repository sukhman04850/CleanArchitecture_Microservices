using CartDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApplication.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> AddToCart(Guid userId, Guid productId);
        Cart GetCartItems(Guid userId);
        List<Products> ViewCartDetails(Guid userId);
        List<OrderItems> ViewOrderItems(Guid userId);

        bool DeleteCartByUserId(Guid userId);
    }
}
