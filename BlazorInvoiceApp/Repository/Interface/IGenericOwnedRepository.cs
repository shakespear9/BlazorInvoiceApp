using BlazorInvoiceApp.Data.Interface;
using BlazorInvoiceApp.DTOs.Interface;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository.Interface
{
    public interface IGenericOwnedRepository<TEntity, TDTO>
        where TEntity : class, IEntity, IOwnedEntity
        where TDTO : class, IDTO, IOwnedDTO
    {
        Task<TDTO> GetMineById(ClaimsPrincipal user, string id);
        Task<List<TDTO>> GetAllMine(ClaimsPrincipal user);
        Task<string> AddMine(ClaimsPrincipal user, TDTO dto);
        Task<TDTO> UpdateMine(ClaimsPrincipal user, TDTO dto);
        Task<bool> DeleteMine(ClaimsPrincipal user, string id);
    }
}
