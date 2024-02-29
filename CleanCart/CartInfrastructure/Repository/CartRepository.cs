using CartApplication.Interfaces;
using CartDomain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartInfrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private static List<Cart> _carts = new List<Cart>();
        public CartRepository()
        {
            
        }
        public List<Cart> AddToCart(Guid userId, Guid productId)
        {

            var existingCart = _carts.FirstOrDefault(c => c.UserId == userId);

            if (existingCart != null)
            {

                var existingCartItem = existingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (existingCartItem == null)
                {

                    existingCart.CartItems.Add(new CartItem { ProductId = productId });
                }
            }
            else
            {

                var newCart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    UserId = userId,
                    CartItems = new List<CartItem> { new CartItem { ProductId = productId } }
                };

                _carts.Add(newCart);
            }

            return _carts;
        }

        public bool DeleteCartByUserId(Guid userId)
        {
            var removeCart = _carts.FirstOrDefault(cart => cart.UserId == userId);
            if (removeCart != null)
            {
                _carts.Remove(removeCart);
                return true;
            }
            return false;
        }

        public Cart GetCartItems(Guid userId)
        {
            var cart = _carts.FirstOrDefault(x => x.UserId == userId);
            if (cart == null)
            {
                throw new Exception("NOT FOUND");
            }

            return cart;
        }

        public List<Products> ViewCartDetails(Guid userId)
        {

            Cart cart = _carts.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                throw new Exception("No Cart Found");

            }
            List<Guid> productIds = new List<Guid>();
            foreach (var cartItem in cart.CartItems)
            {
                productIds.Add(cartItem.ProductId);
            }
            var details = new List<Products>();
            foreach (var productId in productIds)
            {
                var productDetails = GetProductDetails(productId);
                if (productDetails != null)
                {
                    var cartDetails = new Products()
                    {
                        Name = productDetails.Name,
                        ProductId = productDetails.ProductId,
                        Details = productDetails.Details,
                        Price = productDetails.Price

                    };
                    details.Add(cartDetails);


                }


            }
            return details;

        }


        public List<OrderItems> ViewOrderItems(Guid userId)
        {


            Cart cart = _carts.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                throw new Exception("No Cart Found");

            }


            List<Guid> productIds = new List<Guid>();
            foreach (var cartItem in cart.CartItems)
            {
                productIds.Add(cartItem.ProductId);
            }
            var details = new List<OrderItems>();
            foreach (var productId in productIds)
            {
                var productDetails = GetProductDetails(productId);
                if (productDetails != null)
                {
                    var cartDetails = new OrderItems()
                    {
                        ProductId = productDetails.ProductId,
                        Price = productDetails.Price,
                        Name = productDetails.Name,
                    };
                    details.Add(cartDetails);


                }


            }
            return details;


        }
        private Products GetProductDetails(Guid productId)
        {
            HttpClient client = new HttpClient();
            string url = string.Format("http://localhost:5244/api/Product/GetProductById/{0}", productId);
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<Products>(result);
                if (list != null)
                {
                    return list;
                }


            }
            throw new Exception("No Product Response recieved");
        }
    }
}
