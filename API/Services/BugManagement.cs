using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

using DataAccess.Context;
using DataAccess.Entities;

using API.Protos;
using AutoMapper;

namespace API.Services;


public class BugManagerService : BugManager.BugManagerBase
{
    private readonly BugContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<BugManagerService> _logger;
    public BugManagerService(BugContext context, IMapper mapper, ILogger<BugManagerService> logger)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public override Task<SubmitBugResponse> SubmitBug(SubmitBugRequest request, ServerCallContext context)
    {
        Bug bug = _mapper.Map<Bug>(request);

        _context.Bug.Add(bug);
        _context.SaveChanges();

        return Task.FromResult(new SubmitBugResponse
        {
            Response = "Success" 
        });
    }
}
