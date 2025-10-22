using FirstApp.Models.Entities;
using FirstApp.Models.Response;

namespace FirstApp.Models.Mapper;

public class DtoMapper
{
    public static ProductResponse ToProductResponse(Product product)
    {
        ProductResponse response = new ProductResponse()
        {
            PricePerUnit = product.PricePerUnit,
            ProductName = product.ProductName
        };
        return response;
    }
    
    public static CustomerResponse ToCustomerResponse(Customer customer)
    {
        CustomerResponse response = new CustomerResponse()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Age = customer.Age,
            Id = customer.Id,
            CartResponses = ToCartResponseList(customer.Carts)
        };
        return response;
    }

    public static List<CartResponse> ToCartResponseList(List<Cart> customerCarts)
    {
        List<CartResponse> cartResponses = new List<CartResponse>();
        foreach (Cart customer in customerCarts)
        {
            cartResponses.Add(ToCartResponse(customer));
        }
        return cartResponses;
    }

    public static CartResponse ToCartResponse(Cart cart)
    {
        CartResponse cartResponse = new CartResponse()
        {
            Id = cart.Id,
            CartName = cart.CartName,
            Items = ToItemResponseList(cart.Items)
        };
        return cartResponse;
    }

    private static List<ProductResponse> ToProductResponseList(ICollection<Product> customerProducts)
    {
        List<ProductResponse> productResponses = new List<ProductResponse>();
        foreach (Product product in customerProducts)
        {
            productResponses.Add(ToProductResponse(product));
        }
        return productResponses;
    }

    public static List<ItemResponse> ToItemResponseList(List<Item> customerItems)
    {
        List<ItemResponse> responses = new List<ItemResponse>();
        foreach (Item item in customerItems)
        {
            responses.Add(ToItemResponse(item));
        }
        return responses;
    }
    public static ItemResponse ToItemResponse(Item item)
    {
        ItemResponse response = new ItemResponse()
        {
            Product = ToProductResponse(item.Product),
            Quantity = item.Quantity
        };
        return response;
    }
}