using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.Data.Interface;
using BlazorInvoiceApp.DTOs.Interface;
using BlazorInvoiceApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository
{
    public class GenericOwnedRepository<TEntity, TDTO> : IGenericOwnedRepository<TEntity, TDTO>
        where TEntity : class, IEntity, IOwnedEntity
        where TDTO : class, IDTO, IOwnedDTO
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenericOwnedRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        protected string? GetMyUserId(ClaimsPrincipal user)
        {
            Claim? uid = user?.FindFirst(ClaimTypes.NameIdentifier);
            if (uid is not null)
            {
                return uid.Value;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<TDTO>> GetAllMine(ClaimsPrincipal user)
        {
            string? userId = GetMyUserId(user);
            if (userId is not null)
            {
                List<TEntity> entities = await _context.Set<TEntity>().Where(x => x.UserId == userId).ToListAsync();
                List<TDTO> result = _mapper.Map<List<TDTO>>(entities);
                return result;
            }
            else
            {
                return new List<TDTO>();
            }
        }

        public async Task<TDTO> GetMineById(ClaimsPrincipal user, string id)
        {
            string? userId = GetMyUserId(user);
            if (userId is not null)
            {
                TEntity? entities = await _context.Set<TEntity>().Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();
                TDTO result = _mapper.Map<TDTO>(entities);
                return result;
            }
            else
            {
                return null!;
            }
        }
        public virtual async Task<string> AddMine(ClaimsPrincipal User, TDTO dto)
        {
            string? userid = GetMyUserId(User);
            if (userid is not null)
            {
                dto.UserId = userid;
                dto.Id = Guid.NewGuid().ToString();
                TEntity toAdd = _mapper.Map<TEntity>(dto);
                await _context.Set<TEntity>().AddAsync(toAdd);

                return toAdd.Id;
            }
            else
            {
                return null!;
            }
        }
        public async Task<TDTO> UpdateMine(ClaimsPrincipal user, TDTO dto)
        {
            string? userid = GetMyUserId(user);
            if (userid is not null)
            {
                TEntity? toUpdate =
                    await _context.Set<TEntity>().Where(entity => entity.Id == dto.Id && entity.UserId == userid).FirstOrDefaultAsync();

                if (toUpdate is not null)
                {
                    _mapper.Map<TDTO, TEntity>(dto, toUpdate);
                    _context.Entry(toUpdate).State = EntityState.Modified;
                    TDTO result = _mapper.Map<TDTO>(toUpdate);
                    return result;

                }
                else
                {
                    return null!;
                }
            }
            else
            {
                return null!;
            }
        }

        public virtual async Task<bool> DeleteMine(ClaimsPrincipal User, string id)
        {
            string? userid = GetMyUserId(User);
            if (userid is not null)
            {
                TEntity? entity = await _context.Set<TEntity>().Where(entity => entity.Id == id && entity.UserId == userid).FirstOrDefaultAsync();
                if (entity is not null)
                {
                    _context.Remove(entity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        protected async Task<List<TDTO>> GenericQuery(ClaimsPrincipal User, Expression<Func<TEntity, bool>>? expression
            , List<Expression<Func<TEntity, object>>> includes)
        {
            string? userid = GetMyUserId(User);
            if (userid is not null)
            {
                IQueryable<TEntity> query = _context.Set<TEntity>().Where(e => e.UserId == userid);
                if (expression is not null)
                    query = query.Where(expression);

                if (includes is not null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }
                List<TEntity> entities = await query.ToListAsync();

                List<TDTO> result = _mapper.Map<List<TDTO>>(entities);
                return result;
            }
            else
            {
                return new List<TDTO>();
            }
        }




    }
}
