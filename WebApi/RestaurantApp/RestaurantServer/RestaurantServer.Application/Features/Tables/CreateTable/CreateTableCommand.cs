using ErrorOr;
using MediatR;

namespace RestaurantServer.Application.Features.Tables.CreateTable;
public sealed record CreateTableCommand(
    int Number) : IRequest<ErrorOr<Unit>>;
