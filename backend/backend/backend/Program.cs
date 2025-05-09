using backend.Automappers;
using backend.DTOs;
using backend.Models;
using backend.Repository;
using backend.Services;
using backend.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. | Aplicando Inyeccion de Dependencias
//builder.Services.AddSingleton<IPeopleService, PeopleService2>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService2>("peopleService2");
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");
//add Service de Beer
builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");

// HttpClient service Conexion ala API jsonplaceholder
builder.Services.AddHttpClient<IPostsService, PostsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

// Repositories
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();
builder.Services.AddScoped<BeerRepository>();
// Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});



// Validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

// Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
