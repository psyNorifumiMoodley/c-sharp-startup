using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Enitities;
using FirstApp.Models.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController: ControllerBase
{

    private readonly ApplicationDbContext context;
        
    public CartController(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    [HttpPost("{customerId}")]
    public IActionResult SaveCartToCustomer(Guid customerId, CartRequest cartRequest)
    {
        Cart cart = new Cart()
        {
            CartName = cartRequest.CartName,
            Customer = context.Customers.Find(customerId)
        };
        context.Carts.Add(cart);
        context.SaveChanges();
        
        return Ok(DtoMapper.ToCartResponse(cart));
    }

    [HttpGet("{customerId}")]
    public IActionResult GetCart(Guid customerId)
    {
        List<Cart> carts = context.Carts
            .Include(c => c.Customer)
            .Include(i => i.Items).ThenInclude(i => i.Product)
            .Where(c => c.Customer.Id == customerId)
            .ToList();
        foreach (Cart cart in carts)
        {
            Console.WriteLine(cart.Items.Count);    
        }
        return Ok(DtoMapper.ToCartResponseList(carts));
    }
    
    [HttpPost("{customerId}/{cartId}")]
    public IActionResult AddItemToCart(Guid customerId, Guid cartId, ItemRequest itemRequest)
    {
        Item item = new Item()
        {
            Cart = context.Carts.Find(cartId),
            Product = context.Products.Find(itemRequest.ProductId),
            Quantity = itemRequest.Quantity
        };
        context.Items.Add(item);
        context.SaveChanges();
        return Ok(DtoMapper.ToItemResponse(item));
    }
}