using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess;
using ProgramSAP.DataAccess.Repositories;
using ProgramSAP.ApplicationServices.API.Domain;
using ProgramSAP.ApplicationServices.API.Mappings;
using ProgramSAP.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using ProgramSAP.ApplicationServices.API.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using ProgramSAP.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvcCore().
    AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCandidateRequestValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(ResponseBase<>).Assembly);
builder.Services.AddAutoMapper(typeof(CandidatesProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<RecruitingProgramContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingProgramConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
