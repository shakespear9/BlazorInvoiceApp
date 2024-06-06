using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IInvoiceTermsRepository : IGenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>
    {
        public Task Seed(ClaimsPrincipal user);
    }
}
