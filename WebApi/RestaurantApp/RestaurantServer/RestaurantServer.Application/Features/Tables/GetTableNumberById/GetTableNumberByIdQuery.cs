using ErrorOr;
using MediatR;

namespace RestaurantServer.Application.Features.Tables.GetTableNumberById;
public sealed record GetTableNumberByIdQuery(Guid Id): IRequest<ErrorOr<int>>;
