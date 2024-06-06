using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceLineItemRepository : GenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>, IInvoiceLineItemRepository
    {
        public InvoiceLineItemRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }

        public async Task<List<InvoiceLineItemDTO>> GetAllByInvoiceId(ClaimsPrincipal user, string invoiceId)
        {
            return await GenericQuery(user, x => x.InvoiceId == invoiceId);
        }
    }
}
