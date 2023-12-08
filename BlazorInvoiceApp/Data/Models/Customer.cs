using BlazorInvoiceApp.Data.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoiceApp.Data.Models
{
    public class Customer : IEntity, IOwnedEntity
    {

        // told database to not generate Id
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        // link to IdentityUser and nullable foreignKey
        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; }

    }
}
