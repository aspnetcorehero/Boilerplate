using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.ActivityLog.Commands.AddLog
{
    public partial class AddLogCommand : IRequest<Result<int>>
    {
        public string Action { get; set; }
        public string userId { get; set; }
    }
    public class AddLogCommandHandler : IRequestHandler<AddLogCommand, Result<int>>
    {
        private readonly IActivityLogRepository _repo;

        private IUnitOfWork _unitOfWork { get; set; }
        public AddLogCommandHandler(IActivityLogRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(AddLogCommand request, CancellationToken cancellationToken)
        {
            await _repo.AddLogAsync(request.Action,request.userId);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(1);
        }
    }
}
