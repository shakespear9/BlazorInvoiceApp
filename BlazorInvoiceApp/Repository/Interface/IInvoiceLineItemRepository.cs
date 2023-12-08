using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IInvoiceLineItemRepository : IGenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>
    {
    }
}
