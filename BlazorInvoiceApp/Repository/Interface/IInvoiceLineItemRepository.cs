using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IInvoiceLineItemRepository : IGenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>
    {
        public Task<List<InvoiceLineItemDTO>> GetAllByInvoiceId(ClaimsPrincipal user, string invoiceId);
    }
}
