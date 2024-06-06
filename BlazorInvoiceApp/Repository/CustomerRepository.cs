using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository
{
    public class CustomerRepository : GenericOwnedRepository<Customer, CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {

        }

        public async Task Seed(ClaimsPrincipal user)
        {
            var userId = GetMyUserId(user);
            if (user is not null)
            {
                var count = await _context.Customers.Where(c => c.UserId == userId).CountAsync();
                if (count == 0)
                {
                    var defaultCustomer = new CustomerDTO()
                    {
                        Name = "My First Customer"
                    };
                    await AddMine(user, defaultCustomer);
                }
            }
        }
    }
}
