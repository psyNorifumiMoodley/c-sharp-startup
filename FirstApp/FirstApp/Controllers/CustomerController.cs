using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Entities;
using FirstApp.Models.Mapper;
using FirstApp.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FirstApp.Controllers;

//api/customer
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ApplicationDbContext context;

    public CustomerController(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        List<Customer> allCustomers = context.Customers
            .Include(c => c.Carts) // putting "Includes" puts a join on the tables
            .ThenInclude(c => c.Items).ThenInclude(i => i.Product)
            .ToList(); 
        List<CustomerResponse> allCustomerResponses = new List<CustomerResponse>();
        foreach (Customer customer in allCustomers)
        {
            Console.WriteLine(customer.Carts.Count);
            allCustomerResponses.Add(DtoMapper.ToCustomerResponse(customer));
        }
        return Ok(allCustomerResponses);
    }

    [HttpPost]
    public async Task<IActionResult> SaveCustomer(CustomerRequest customerRequest)
    {
        // if (!ModelState.IsValid) //not needed
        // {
        //     return BadRequest(ModelState);
        // }
        var customerEntity = new Customer()
        {
            FirstName = customerRequest.FirstName,
            LastName = customerRequest.LastName,
            Age = customerRequest.Age
        };

        context.Customers.Add(customerEntity);
        await context.SaveChangesAsync();
        return Ok(customerEntity);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(Guid customerId)
    {
        context.Customers.Remove(context.Customers.Find(customerId));
        await context.SaveChangesAsync();
        return Ok("Deleted Customer");
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateCustomer(CustomerRequest customerRequest,  Guid customerId)
    {
        Customer updatedCustomer = new Customer()
        {
            FirstName = customerRequest.FirstName,
            LastName = customerRequest.LastName,
            Age = customerRequest.Age,
            Id = customerId
        };
        context.Customers.Update(updatedCustomer);  //unlike spring, you have to use update instead of save because otherwise it will try to create a new entry with the same primary key
        await context.SaveChangesAsync();
        return Ok(DtoMapper.ToCustomerResponse(updatedCustomer));
    }

    [HttpGet("{customerId}")]
    public IActionResult GetCustomerById(Guid customerId)
    {
        var customer = context.Customers
            .Include(c => c.Carts)
            .ThenInclude(c => c.Items).ThenInclude(i => i.Product)
            .First(c => c.Id == customerId);
        return Ok(DtoMapper.ToCustomerResponse(customer));
    }
}