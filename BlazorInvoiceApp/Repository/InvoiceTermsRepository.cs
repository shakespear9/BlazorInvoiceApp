using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceTermsRepository : GenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>, IInvoiceTermsRepository
    {
        public InvoiceTermsRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }

        public async Task Seed(ClaimsPrincipal user)
        {
            var userId = GetMyUserId(user);
            if (user is not null)
            {
                var count = await _context.InvoiceTerms.Where(c => c.UserId == userId).CountAsync();
                if (count == 0)
                {
                    // seed data
                    var terms1 = new InvoiceTermsDTO()
                    {
                        Name = "Net 30"
                    };
                    var terms2 = new InvoiceTermsDTO()
                    {
                        Name = "Net 60"
                    };
                    var terms3 = new InvoiceTermsDTO()
                    {
                        Name = "Net 90"
                    };
                    await AddMine(user, terms1);
                    await AddMine(user, terms2);
                    await AddMine(user, terms3);
                }
            }
        }
    }
}
