namespace RestaurantServer.Application.Features.Tables.GetAllTable;

public sealed record GetAllTableQueryResponse(
    Guid Id,
    int Number,
    bool IsAvailable);