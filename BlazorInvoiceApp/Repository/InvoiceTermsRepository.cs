using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceTermsRepository : GenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>, IInvoiceTermsRepository
    {
        public InvoiceTermsRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
