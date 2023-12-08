namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IInvoiceLineItemRepository InvoiceLineItemRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceTermsRepository InvoiceTermsRepository { get; }
        Task<int> Save();
    }
}
