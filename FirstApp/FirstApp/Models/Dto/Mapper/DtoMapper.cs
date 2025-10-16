using FirstApp.Models.Enitities;
using FirstApp.Models.Response;

namespace FirstApp.Models.Mapper;

public class DtoMapper
{
    public static ProductResponse ToProductResponse(Product product)
    {
        ProductResponse response = new ProductResponse()
        {
            CustomerId = product.Customer.Id,
            PricePerUnit = product.PricePerUnit,
            ProductName = product.ProductName
        };
        return response;
    }
    
    public static CustomerResponse ToCustomerResponse(Customer customer)
    {
        Console.WriteLine(customer.Products.Count);
        CustomerResponse response = new CustomerResponse()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Id = customer.Id,
            Products = ToProductResponseList(customer.Products)
        };
        return response;
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
}