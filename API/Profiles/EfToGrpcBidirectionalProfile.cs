using AutoMapper;

using API.Protos;
using DataAccess.Entities;

namespace API.Profiles;


public class EfToGrpcBidirectionalProfile : Profile
{
    public EfToGrpcBidirectionalProfile()
    {
        CreateMap<SubmitBugRequest, Bug>();
        CreateMap<Bug, SubmitBugRequest>();

        CreateMap<SubmitCommentRequest, Comment>();
        CreateMap<Comment, SubmitCommentRequest>();
    }
}
