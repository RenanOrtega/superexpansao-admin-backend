using Core.Models;
using Core.Models.Request;
using Core.Repositories.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MapeadorRepository(AppDbContext context) : Repository<Mapeador>(context), IMapeadorRepository
{
    private readonly AppDbContext _context = context;
    public IQueryable<Mapeador> GetWithFilters(MapeadorFilterParams filters)
    {
        var query = _context.Mapeadores.AsQueryable();
        
        if (!string.IsNullOrEmpty(filters.Name))
            query = query.Where(m => m.Name.Contains(filters.Name));

        if (!string.IsNullOrEmpty(filters.City))
            query = query.Where(m => m.City.Contains(filters.City));

        if (!string.IsNullOrEmpty(filters.Vehicle))
            query = query.Where(m => m.Vehicle.Contains(filters.Vehicle));

        if (filters.LastMapping.HasValue)
            query = query.Where(m => m.LastMapping.Date == filters.LastMapping.Value.Date);
        
        return query;
    }
}