﻿using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Rent.DeleteRent;

public class DeleteRentCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}