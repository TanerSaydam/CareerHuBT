﻿using LiveSupportServer.Domain.ChatRooms;
using MediatR;

namespace LiveSupportServer.Application.Features.Admin.GetAllChatRoom;
public sealed record GetAllChatRoomQuery(
    string Empty = ""):IRequest<List<ChatRoom>>;
