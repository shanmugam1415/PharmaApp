using Amazon.S3;
using MediatR;
using PharmaApp.API.Extensions;
using PharmaApp.Application;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLog4net();
IConfiguration configuration = builder.Configuration;
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSService<IAmazonS3>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();
app.UseErrorHandler();
app.MapControllers();
app.Run();
