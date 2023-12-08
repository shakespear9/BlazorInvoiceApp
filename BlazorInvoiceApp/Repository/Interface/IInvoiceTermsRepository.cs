using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IInvoiceTermsRepository : IGenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>
    {
    }
}
