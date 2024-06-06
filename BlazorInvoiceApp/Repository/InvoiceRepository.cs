using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Models;
using BlazorInvoiceApp.DTOs;
using BlazorInvoiceApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceRepository : GenericOwnedRepository<Invoice, InvoiceDTO>, IInvoiceRepository
    {
        public InvoiceRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }

        public async Task DeleteInvoiceWithAllLineItems(ClaimsPrincipal user, string invoiceId)
        {
            string? userId = GetMyUserId(user);
            if (userId is not null)
            {
                var lineItems = await _context.InvoiceLineItems.Where(x => x.InvoiceId == invoiceId && x.UserId == userId).ToListAsync();
                if (lineItems.Count > 0)
                {
                    _context.InvoiceLineItems.RemoveRange(lineItems);
                }

                var invoice = await _context.Invoices.Where(x => x.Id == invoiceId && x.UserId == userId).FirstOrDefaultAsync();
                if (invoice is not null)
                {
                    _context.Invoices.Remove(invoice);
                }
            }
        }

        public async Task<List<InvoiceDTO>> GetAllMineFlat(ClaimsPrincipal user)
        {
            string? userId = GetMyUserId(user);
            //if (userId is not null)
            //{
            var invoiceDTO = await _context.Invoices.Where(x => x.UserId == userId)
                .Include(x => x.InvoiceTerms)
                .Include(x => x.Customer)
                .Include(x => x.InvoiceLineItems)
                .Select(x => new InvoiceDTO()
                {
                    Id = x.Id,
                    CreateDate = x.CreateDate,
                    InvoiceNumber = x.InvoiceNumber,
                    Description = x.Description,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer!.Name,
                    InvoiceTermsId = x.InvoiceTermsId,
                    InvoiceTermsName = x.InvoiceTerms!.Name,
                    Paid = x.Paid,
                    Credit = x.Credit,
                    TaxRate = x.TaxRate,
                    InvoiceTotal = x.InvoiceLineItems.Sum(a => a.TotalPrice),
                    UserId = x.UserId,
                }).ToListAsync();

            return invoiceDTO;
            //}
        }
    }
}
