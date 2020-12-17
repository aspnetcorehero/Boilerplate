using AspNetCoreHero.Boilerplate.Application.DTOs;
using AspNetCoreHero.Boilerplate.Application.Interfaces;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Contexts;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using AspNetCoreHero.EntityFrameworkCore.Auditing.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Audit> _repository;
        private readonly IDateTimeService _dateTimeService;
        public ActivityLogRepository(IRepositoryAsync<Audit> repository, IMapper mapper, IDateTimeService dateTimeService)
        {
            _repository = repository;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
        }


        public async Task AddLogAsync(string action, string userId)
        {
            var audit = new Audit()
            {
                Type = action,
                UserId = userId,
                DateTime = _dateTimeService.NowUtc
            };
            await _repository.AddAsync(audit);
        }

        public async Task<List<ActivityLogResponse>> GetListAsync(string userId)
        {
            var logs = await _repository.Entities.Where(a => a.UserId == userId).OrderByDescending(a => a.DateTime).Take(250).ToListAsync();
            var mappedLogs = _mapper.Map<List<ActivityLogResponse>>(logs);
            return mappedLogs;
        }
    }
    public class ActivityLogProfile : Profile
    {
        public ActivityLogProfile()
        {
            CreateMap<ActivityLogResponse, Audit>().ReverseMap();
        }
    }
}
