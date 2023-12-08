using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceRepository : GenericOwnedRepository<Invoice, InvoiceDTO>, IInvoiceRepository
    {
        public InvoiceRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
