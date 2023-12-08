using BlazorInvoiceApp.DTOs.Interface;

namespace BlazorInvoiceApp.DTOs
{
    public class CustomerDTO : IDTO, IOwnedDTO
    {
        public string Id { get; set; } = String.Empty;
        public string UserId { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;

    }
}
