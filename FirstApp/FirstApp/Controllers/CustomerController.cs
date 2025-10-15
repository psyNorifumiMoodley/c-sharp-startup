using FirstApp.Data;
using FirstApp.Models;
using FirstApp.Models.Enitities;
using Microsoft.AspNetCore.Mvc;
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
        List<Customer> allCustomers = context.Customers.ToList();
        return Ok(allCustomers);
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