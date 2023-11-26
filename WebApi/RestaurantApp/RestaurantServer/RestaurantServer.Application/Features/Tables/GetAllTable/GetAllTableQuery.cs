using ErrorOr;
using MediatR;

namespace RestaurantServer.Application.Features.Tables.GetAllTable;
public sealed record GetAllTableQuery() : IRequest<ErrorOr<List<GetAllTableQueryResponse>>>;
