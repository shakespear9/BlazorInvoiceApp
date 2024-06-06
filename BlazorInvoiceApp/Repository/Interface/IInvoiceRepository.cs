using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IInvoiceRepository : IGenericOwnedRepository<Invoice, InvoiceDTO>
    {
        public Task DeleteInvoiceWithAllLineItems(ClaimsPrincipal user, string invoiceId);
        public Task<List<InvoiceDTO>> GetAllMineFlat(ClaimsPrincipal user);
    }
}
