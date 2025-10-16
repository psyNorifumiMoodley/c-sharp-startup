using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Enitities;
using FirstApp.Models.Mapper;
using FirstApp.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext context;

    public ProductController(ApplicationDbContext context)
    {
        this.context = context;
    }
    [HttpPost]
    public IActionResult SaveProduct(ProductRequest productRequest)
    {
        var productEntity = new Product()
        {
            ProductName = productRequest.ProductName,
            PricePerUnit = productRequest.PricePerUnit,
            Customer = context.Customers.Find(productRequest.CustomerId)
        };
        context.Products.Add(productEntity);
        context.SaveChanges();

        ProductResponse productResponse = DtoMapper.ToProductResponse(productEntity);
        return Ok(productResponse);
    }
}