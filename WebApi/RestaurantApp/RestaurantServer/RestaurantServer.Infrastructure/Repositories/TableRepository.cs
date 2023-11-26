using Microsoft.EntityFrameworkCore;
using RestaurantServer.Domain.Tables;
using RestaurantServer.Infrastructure.Context;

namespace RestaurantServer.Infrastructure.Repositories;
internal sealed class TableRepository : ITableRepository
{
    private readonly ApplicationDbContext _context;

    public TableRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckNumberIsExistsAsync(int number, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Table>().AnyAsync(p => p.Number == number, cancellationToken);
    }

    public async Task CreateAsync(Table table, CancellationToken cancellationToken = default)
    {
        await _context.Set<Table>().AddAsync(table, cancellationToken);
    }

    public IQueryable<Table> GetAll()
    {
        return _context.Set<Table>().AsQueryable();
    }

    public async Task<int> GetTableNumberByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Table>().Where(p => p.Id == id).Select(s => s.Number).FirstOrDefaultAsync(cancellationToken);
    }

    public Task UpdateAsync(Table table, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
