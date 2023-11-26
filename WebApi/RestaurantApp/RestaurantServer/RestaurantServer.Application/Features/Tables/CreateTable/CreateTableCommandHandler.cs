using ErrorOr;
using MediatR;
using RestaurantServer.Domain.Abstractions;
using RestaurantServer.Domain.Tables;

namespace RestaurantServer.Application.Features.Tables.CreateTable;

internal sealed class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, ErrorOr<Unit>>
{
    private readonly ITableRepository _tableRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateTableCommandHandler(ITableRepository tableRepository, IUnitOfWork unitOfWork)
    {
        _tableRepository = tableRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        var isNumberIsExists = await _tableRepository.CheckNumberIsExistsAsync(request.Number, cancellationToken);
        if (isNumberIsExists)
        {
            return Error.Failure(code: "NumberIsExists", "Bu masa numarası daha önce kullanılmış");
        }

        if (request.Number < 1)
        {
            return Error.Conflict(code: "NumberCannotBeSmallOne", "Masa numarası 1 den küçük olamaz");
        }

        Table table = new(request.Number);

        await _tableRepository.CreateAsync(table, cancellationToken);      

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
