using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Enitities;
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
            .Include(c => c.Products) // putting "Includes" puts a join on the tables
            .ToList(); 
        List<CustomerResponse> allCustomerResponses = new List<CustomerResponse>();
        foreach (Customer customer in allCustomers)
        {
            Console.WriteLine(customer.Products.Count);
            allCustomerResponses.Add(DtoMapper.ToCustomerResponse(customer));
        }
        return Ok(allCustomerResponses);
    }

    [HttpPost]
    public IActionResult SaveCustomer(CustomerRequest customerRequest)
    {
        var customerEntity = new Customer()
        {
            FirstName = customerRequest.FirstName,
            LastName = customerRequest.LastName
        };

        context.Customers.Add(customerEntity);
        context.SaveChanges();
        return Ok(customerEntity);
    }
}