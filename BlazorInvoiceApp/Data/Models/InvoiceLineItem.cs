using BlazorInvoiceApp.Data.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoiceApp.Data.Models
{
    public class InvoiceLineItem : IEntity, IOwnedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string InvoiceId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        // private set calculate from UnitPrice field multiply by Quantity field
        public double TotalPrice { get; private set; }

        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; }
    }
}
