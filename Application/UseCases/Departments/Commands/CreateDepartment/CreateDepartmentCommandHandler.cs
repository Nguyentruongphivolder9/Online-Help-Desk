﻿using Application.Common.Messaging;
using Domain.Entities.Departments;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Departments.Commands.CreateDepartment
{
    public sealed class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand>
    {

        private readonly IUnitOfWorkRepository _repo;

        public CreateDepartmentCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                DepartmentName = request.DepartmentName
            };

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                return Result.Success("Create Department successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.DepartmentHandler", "There is an error saving data!");
                return Result.Failure(error, "Create department failed!");
            }
        }
    }
}
