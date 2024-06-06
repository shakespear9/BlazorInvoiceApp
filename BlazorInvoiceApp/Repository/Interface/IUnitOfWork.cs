namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IInvoiceLineItemRepository InvoiceLineItem { get; }
        ICustomerRepository Customer { get; }
        IInvoiceRepository Invoice { get; }
        IInvoiceTermsRepository InvoiceTerms { get; }
        Task<int> Save();
    }
}
