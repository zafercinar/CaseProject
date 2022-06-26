using AutoMapper;
using CaseProject.Business.MappingProfiles;
using CaseProject.Business.Services.Abstract;
using CaseProject.Business.Services.Concrete;
using CaseProject.DataAccess.Contexts;
using CaseProject.DataAccess.Repositories.Abstract;
using CaseProject.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<CaseProjectDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CaseProjectDb")));

builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddTransient<IWordService, WordService>();
builder.Services.AddSingleton<IRandomTextService, RandomTextService>();

//Auto Mapper Profile
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new WordMappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Word}/{action=Index}/{id?}");

app.Run();
