using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantServer.Domain.Tables;

namespace RestaurantServer.Application.Features.Tables.GetAllTable;

internal sealed class GetAllTableQueryHandler : IRequestHandler<GetAllTableQuery, ErrorOr<List<GetAllTableQueryResponse>>>
{
    private readonly ITableRepository _tableRepository;
    public GetAllTableQueryHandler(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }
    public async Task<ErrorOr<List<GetAllTableQueryResponse>>> Handle(GetAllTableQuery request, CancellationToken cancellationToken)
    {
        List<GetAllTableQueryResponse> tables =
            await _tableRepository
            .GetAll()
            .OrderBy(p=> p.Number)
            .Select(s => new GetAllTableQueryResponse(
                s.Id, 
                s.Number,
                s.IsAvailable))
            .ToListAsync(cancellationToken);

        return tables;
    }
}
