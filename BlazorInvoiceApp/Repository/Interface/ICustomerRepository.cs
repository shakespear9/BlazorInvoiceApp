using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface ICustomerRepository : IGenericOwnedRepository<Customer, CustomerDTO>
    {
        public Task Seed(ClaimsPrincipal user);
    }
}
