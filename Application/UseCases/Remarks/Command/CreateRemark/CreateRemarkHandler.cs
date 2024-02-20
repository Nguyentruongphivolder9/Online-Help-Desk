using Application.Common.Messaging;
using Application.DTOs.Remarks;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Entities.Requests;
using Domain.Repositories;

using SharedKernel;
using System.Collections.Generic;

namespace Application.UseCases.Remarks.Command.CreateRemark
{
    public sealed class CreateRemarkHandler : ICommandHandler<CreateRemarkCommand, RemarkDTO>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;
        public CreateRemarkHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<RemarkDTO>> Handle(CreateRemarkCommand request, CancellationToken cancellationToken)
        {
            var remarkData = new Remark
            {
                Id = new Guid(),
                AccountId = request.accountId,
                RequestId = new Guid(request.requestId),
                Comment = request.comment,
                CreateAt = DateTime.Now,
                Enable = true
            };

            _repo.remarkRepo.Add(remarkData);


            try
            {
                await _repo.SaveChangesAsync(cancellationToken);

                var latestRemark = await _repo.remarkRepo.GetLatestRemark(remarkData.Id.ToString().ToUpper());
                var latestRemarkMapper = _mapper.Map<RemarkDTO>(latestRemark);
                return Result.Success<RemarkDTO>(latestRemarkMapper, "Create remark successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.RemarkCommandHandler", "There is an error saving data!");
                return Result.Failure<RemarkDTO>(error, "Create Remark failed!");
            }
        }
    }
}
