using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceLineItemRepository : GenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>, IInvoiceLineItemRepository
    {
        public InvoiceLineItemRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
