using BlazorInvoiceApp.DTOs.Interface;

namespace BlazorInvoiceApp.DTOs
{
    public class InvoiceLineItemDTO : IDTO, IOwnedDTO
    {
        public string Id { get; set; } = string.Empty;
        public string InvoiceId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string UserId { get; set; } = null!;
    }
}
