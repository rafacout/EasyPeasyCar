using EasyPeasy.Application.Mapping;
using EasyPeasy.Application.Queries.Category.GetAllCategories;
using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Context;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "EasyPeasy.API", Version = "v1", Description = "API Documentation of the EasyPeasy Rental Car System" });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesQuery).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufactureRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<EasyPeasyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation of the EasyPeasy Rental Car System");
        c.RoutePrefix = string.Empty; // Isso faz o Swagger aparecer na raiz, em vez de /swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#if DEBUG
//ApplyMigrations(app);
#endif

app.Run();

void ApplyMigrations(IHost app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<EasyPeasyDbContext>();
    dbContext.Database.Migrate();
}