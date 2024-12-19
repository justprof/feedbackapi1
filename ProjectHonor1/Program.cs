using ProjectHonor1.Models;

using ProjectHonor1.Repositories.CategoryRepository;
using ProjectHonor1.Repositories.FeedbackRepository;
using ProjectHonor1.Repositories.StatusRepository;

using MySql.Data.MySqlClient;
using System.Data;
using ProjectHonor1.Repositories.GetCategoryDtos;
using ProjectHonor1.Repositories.GetStatusDtos;
using ProjectHonor1.Repositories.GetFeedbackDtos;

var builder = WebApplication.CreateBuilder(args);
// Connection string'i okuma

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddSingleton(new DapperContext(connectionString));
builder.Services.AddScoped<IDbConnection>(db => new MySqlConnection(connectionString));

//Repository ve service için DI konteynýra ekleme
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
