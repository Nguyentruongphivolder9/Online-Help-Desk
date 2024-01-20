﻿using Application.Common.Messaging;
using Domain.Entities.Departments;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Rooms.Commands.CreateRoom
{
    public sealed class CreateRoomCommandHandler: ICommandHandler<CreateRoomCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public CreateRoomCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                DepartmentId = request.DepartmentId,
                RoomNumber = request.RoomNumber,
                RoomStatus = request.RoomStatus,
            };

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);

                return Result.Success("Create Room successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Error error = new("Error.RoomCommandHandler", "There is an error saving data!");
                return Result.Failure(error, "Create Room failed!");
            }
        }
    }
}
