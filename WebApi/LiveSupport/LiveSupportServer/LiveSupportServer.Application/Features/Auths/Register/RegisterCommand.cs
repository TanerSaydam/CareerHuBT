using MediatR;

namespace LiveSupportServer.Application.Features.Auths.Register;
public sealed record RegisterCommand(
    string Name,
    string UserName,
    string Password) : IRequest;