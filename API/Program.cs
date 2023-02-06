using API.Profiles;
using API.Services;
using AutoMapper;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BugContext>(options =>
{
    options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=BugDB;Trusted_Connection=True;Encrypt=False;");
});

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddSingleton(config => new MapperConfiguration(cfg =>
{
    cfg.AddProfile<EfToGrpcBidirectionalProfile>();
}).CreateMapper());

const string corsPolicy = "_corsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//app.MapGrpcService<BugManagerService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.UseCors(corsPolicy);
app.UseRouting();
app.UseGrpcWeb();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<BugManagerService>().EnableGrpcWeb();
});

app.Run();
