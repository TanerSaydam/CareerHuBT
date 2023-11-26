using ErrorOr;
using MediatR;
using RestaurantServer.Domain.Tables;

namespace RestaurantServer.Application.Features.Tables.GetTableNumberById;

internal sealed class GetTableNumberByIdQueryHandler : IRequestHandler<GetTableNumberByIdQuery, ErrorOr<int>>
{
    private readonly ITableRepository _tableRepository;

    public GetTableNumberByIdQueryHandler(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }

    public async Task<ErrorOr<int>> Handle(GetTableNumberByIdQuery request, CancellationToken cancellationToken)
    {
        return await _tableRepository.GetTableNumberByIdAsync(request.Id);
    }
}
