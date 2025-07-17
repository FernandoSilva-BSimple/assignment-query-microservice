using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Domain.Factory.AssignmentFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using InterfaceAdapters;
using InterfaceAdapters.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AssignmentContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//Services
builder.Services.AddTransient<IAssignmentService, AssignmentService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDeviceService, DeviceService>();
builder.Services.AddTransient<ICollaboratorService, CollaboratorService>();

//Repositories
builder.Services.AddTransient<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDeviceRepository, DeviceRepository>();
builder.Services.AddTransient<ICollaboratorRepository, CollaboratorRepository>();

//Factories
builder.Services.AddScoped<IAssignmentFactory, AssignmentFactory>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddScoped<IDeviceFactory, DeviceFactory>();
builder.Services.AddScoped<ICollaboratorFactory, CollaboratorFactory>();

//Mappers
builder.Services.AddAutoMapper(cfg =>
{
    //DTO
    cfg.CreateMap<Assignment, AssignmentDTO>();
    cfg.CreateMap<IAssignment, AssignmentDTO>();
    cfg.CreateMap<AssignmentDTO, Assignment>();

    cfg.CreateMap<Collaborator, CollaboratorDTO>();
    cfg.CreateMap<ICollaborator, CollaboratorDTO>();
    cfg.CreateMap<CollaboratorDTO, Collaborator>();

    cfg.CreateMap<User, UserDTO>();
    cfg.CreateMap<IUser, UserDTO>();
    cfg.CreateMap<UserDTO, User>();

    cfg.CreateMap<Device, DeviceDTO>();
    cfg.CreateMap<IDevice, DeviceDTO>();
    cfg.CreateMap<DeviceDTO, Device>();

});


// MassTransit
var instanceId = InstanceInfo.InstanceId;

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AssignmentCreatedConsumer>();
    x.AddConsumer<AssignmentUpdatedConsumer>();
    x.AddConsumer<CollaboratorCreatedConsumer>();
    x.AddConsumer<UserCreatedConsumer>();
    x.AddConsumer<DeviceCreatedConsumer>();


    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("localhost", 5674, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint($"assignments-query-{instanceId}", e =>
        {
            e.ConfigureConsumer<AssignmentCreatedConsumer>(ctx);
            e.ConfigureConsumer<AssignmentUpdatedConsumer>(ctx);
            e.ConfigureConsumer<CollaboratorCreatedConsumer>(ctx);
            e.ConfigureConsumer<UserCreatedConsumer>(ctx);
            e.ConfigureConsumer<DeviceCreatedConsumer>(ctx);
        });
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();



app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
