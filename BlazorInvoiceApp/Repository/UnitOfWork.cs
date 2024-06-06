using AutoMapper;
using BlazorInvoiceApp.Common.Exceptions;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorInvoiceApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IInvoiceLineItemRepository InvoiceLineItem { get; private set; }

        public ICustomerRepository Customer { get; private set; }

        public IInvoiceRepository Invoice { get; private set; }

        public IInvoiceTermsRepository InvoiceTerms { get; private set; }

        public UnitOfWork(IMapper mapper, IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _mapper = mapper;
            _context = contextFactory.CreateDbContext();
            InvoiceLineItem = new InvoiceLineItemRepository(_mapper, _context);
            Customer = new CustomerRepository(_mapper, _context);
            Invoice = new InvoiceRepository(_mapper, _context);
            InvoiceTerms = new InvoiceTermsRepository(_mapper, _context);
        }

        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                foreach (EntityEntry item in ex.Entries)
                {
                    if (item.State == EntityState.Modified)
                    {
                        item.CurrentValues.SetValues(item.OriginalValues);
                        item.State = EntityState.Unchanged;
                        throw new RepositoryUpdateException();
                    }
                    else if (item.State == EntityState.Deleted)
                    {
                        item.State = EntityState.Unchanged;
                        throw new RepositoryDeleteException();
                    }
                    else if (item.State == EntityState.Added)
                    {
                        throw new RepositoryAddException();
                    }
                }
            }
            return 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
