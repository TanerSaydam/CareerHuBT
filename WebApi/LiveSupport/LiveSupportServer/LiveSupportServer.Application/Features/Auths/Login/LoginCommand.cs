using MediatR;

namespace LiveSupportServer.Application.Features.Auths.Login;
public sealed record LoginCommand(
    string UserName,
    string Password) : IRequest<string>;