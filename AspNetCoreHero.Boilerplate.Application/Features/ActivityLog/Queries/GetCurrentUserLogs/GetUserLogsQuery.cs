using AspNetCoreHero.Boilerplate.Application.DTOs;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.ActivityLog.Queries.GetUserLogs
{

    public class GetUserLogsQuery : IRequest<Result<List<ActivityLogResponse>>>
    {
        public string userId { get; set; }
        public GetUserLogsQuery()
        {

        }
    }

    public class GetUserLogsQueryHandler : IRequestHandler<GetUserLogsQuery, Result<List<ActivityLogResponse>>>
    {
        private readonly IActivityLogRepository _repo;
        private readonly IMapper _mapper;

        public GetUserLogsQueryHandler(IActivityLogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<List<ActivityLogResponse>>> Handle(GetUserLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _repo.GetListAsync(request.userId);
            return Result<List<ActivityLogResponse>>.Success(logs);
        }
    }
}
