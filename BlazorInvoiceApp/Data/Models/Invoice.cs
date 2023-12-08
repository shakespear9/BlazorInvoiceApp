using BlazorInvoiceApp.Data.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoiceApp.Data.Models
{
    public class Invoice : IEntity, IOwnedEntity
    {
        // told database to not generate Id
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // told database to generate Id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        // link to customer entity
        public string CustomerId { get; set; } = string.Empty;
        public Customer? Customer { get; set; }
        // link to invoice terms entity
        public string InvoiceTermsId { get; set; } = string.Empty;
        public InvoiceTerms? InvoiceTerms { get; set; }
        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; }

        public double Paid { get; set; } = 0;
        public double Credit { get; set; } = 0;
        public double TaxRate { get; set; } = 0;

        public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>();

    }
}
