using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Enitities;
using FirstApp.Models.Mapper;
using FirstApp.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    public IActionResult Post(ProductRequest productRequest)
    {
        Product product = new Product()
        {
            ProductName = productRequest.ProductName,
            PricePerUnit = productRequest.PricePerUnit
        };
        context.Products.Add(product);
        context.SaveChanges();
        return Ok(DtoMapper.ToProductResponse(product));
    }
    
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(context.Products.ToList());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetProductById(Guid id)
    {
        Product? product = context.Products.Find(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }

        return Ok(product);

    }
    
    // public async Task<IActionResult> TransactionTest()
    // {
    //     var transaction = context.Database.BeginTransaction();
    //     try
    //     {
    //         context.Customers.Add(new Customer()
    //         {
    //             FirstName = "Transaction",
    //             LastName = "Test"
    //         });
    //         
    //         context.SaveChanges();              // Waits for database operation to finish
    //         await context.SaveChangesAsync();   // Frees up the thread while waiting for the database to respond (preferred)
    //         
    //         transaction.Commit();
    //     }
    //     catch (Exception e)
    //     {
    //         transaction.Rollback();
    //         return BadRequest("error in transaction");
    //     }
    //     return Ok();
    // }
}