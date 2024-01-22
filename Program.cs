using ECommersShop.FacadPattern;
using ECommersShop.FacadPattern.Carts;
using ECommersShop.FacadPattern.Categories;
using ECommersShop.FacadPattern.Finances;
using ECommersShop.FacadPattern.Products;
using ECommersShop.FacadPattern.Roles;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("postgresServer"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// User Services Inject
builder.Services.AddTransient<IUsersServicesFacad, UsersServicesFacad>();

// Roles Services Inject
builder.Services.AddTransient<IRolesSeviceFacad, RolesSeviceFacad>();

// Products Services Inject
builder.Services.AddTransient<IProductsServiceFacad, ProductsServiceFacad>();

// Categeries Services Inject
builder.Services.AddTransient<ICategoriesServiceFacad, CategoriesServiceFacad>();

// Carts Services Inject
builder.Services.AddTransient<ICartServiceFacad, CartServiceFacad>();

// Finance Service Inject
builder.Services.AddTransient<IFinancesServiceFacad, FinancesServiceFacad>();

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