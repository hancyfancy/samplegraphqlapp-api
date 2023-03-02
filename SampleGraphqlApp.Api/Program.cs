using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Data.Repositories;
using SampleGraphqlApp.Service.Interface.Services;
using SampleGraphqlApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "permittedSpecificOrigins",
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

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

app.UseCors("permittedSpecificOrigins");

app.Run();
