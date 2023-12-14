using ECommersShop.FacadPattern;
using ECommersShop.FacadPattern.Roles;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContex>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("postgresServer"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// User Services Inject
builder.Services.AddTransient<IUsersServicesFacad, UsersServicesFacad>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();