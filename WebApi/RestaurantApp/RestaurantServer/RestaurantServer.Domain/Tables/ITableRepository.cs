namespace RestaurantServer.Domain.Tables;
public interface ITableRepository
{
    Task CreateAsync(Table table, CancellationToken cancellationToken = default);
    Task UpdateAsync(Table table, CancellationToken cancellationToken = default);
    IQueryable<Table> GetAll();
    Task<bool> CheckNumberIsExistsAsync(int number, CancellationToken cancellationToken = default);

    Task<int> GetTableNumberByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
