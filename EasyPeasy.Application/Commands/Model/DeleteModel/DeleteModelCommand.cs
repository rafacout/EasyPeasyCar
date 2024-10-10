using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Model.DeleteModel;

public class DeleteModelCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}