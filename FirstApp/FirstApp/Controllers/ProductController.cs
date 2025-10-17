using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Enitities;
using FirstApp.Models.Mapper;
using FirstApp.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    
    [HttpPost("{customerId}")]
    public async Task<IActionResult> SaveProduct(Guid customerId, ProductRequest productRequest)
    {
        var productEntity = new Product()
        {
            ProductName = productRequest.ProductName,
            PricePerUnit = productRequest.PricePerUnit,
            Customer = context.Customers.Find(customerId)
        };
        context.Products.Add(productEntity);
        await context.SaveChangesAsync();

        ProductResponse productResponse = DtoMapper.ToProductResponse(productEntity);
        return Ok(productResponse);
    }

    [HttpGet("{customerId}")]
    public IActionResult GetProductsForCustomer(Guid customerId)
    {
        List<Product> products = context.Products
            .Include(p => p.Customer)
            .Where(p => p.Customer.Id == customerId)
            .ToList();
        List<ProductResponse> productResponses = new List<ProductResponse>();
        foreach (Product product in products)
        {
            productResponses.Add(DtoMapper.ToProductResponse(product));
        }
        return Ok(productResponses);
    }
    
    public async Task<IActionResult> TransactionTest()
    {
        var transaction = context.Database.BeginTransaction();
        try
        {
            context.Customers.Add(new Customer()
            {
                FirstName = "Transaction",
                LastName = "Test"
            });
            
            context.SaveChanges();              // Waits for database operation to finish
            await context.SaveChangesAsync();   // Frees up the thread while waiting for the database to respond (preferred)
            
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            return BadRequest("error in transaction");
        }
        return Ok();
    }
}