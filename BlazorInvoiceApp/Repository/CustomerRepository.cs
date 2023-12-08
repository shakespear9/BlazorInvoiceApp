using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;

namespace BlazorInvoiceApp.Repository
{
    public class CustomerRepository : GenericOwnedRepository<Customer, CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {

        }
    }
}
