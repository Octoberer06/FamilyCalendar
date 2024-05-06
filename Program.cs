using Calendar.DataAccess;
using Calendar.DataAccess.Entities;
using Calendar.DataAccess.Repository;
using FamilyCalendar.Calendar.Application.Interfaces;
using FamilyCalendar.Calendar.Application.Services;
using FamilyCalendar.Calendar.Core.Abstractions;
using FamilyCalendar.Calendar.DataAccess.Repository;
using FamilyCalendar.Extensions;
using FamilyCalendar.Infrastructure;
using FamilyCalendar.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<CalendarDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(CalendarDbContext)));
    });
// регистрируем наши интерфейсы 
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ICalendarEventsReposytory, CalendarEventsReposytory>();

// Всё что связанно с User, его регистрацией и т.п.
//builder.Services.AddDbContext<UserDbContext>(
//    options =>
//    {
//        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(UserDbContext)));
//    });
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped< UsersService >();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<JwtProvider>();


//builder.Services.AddHttpContextAccessor(); // Для разлогинивания
//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    // Конфигурация приложения...
//    app.UseRouting();
//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllers();
//    });
//}

builder.Services.AddAutoMapper(typeof(DataBaseMappings));

builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddRazorPages(); // 03.05.2024 20:40
builder.Services.AddControllersWithViews(); // 05.05.2024 16:19

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });


    //app.UseExceptionHandler("/Home/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); }); // 03.05.2024 20:40

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(); // 04.05.2024 13:24

// код ниже эксперементы (см папку Endpoints)
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapUsersEndpoints(); // Добавление маршрутов эндпоинтов Users
//});

app.UseAuthentication();
app.UseAuthorization();

// код ниже эксперементы (см папку Endpoints)
//app.AddMappedEndpoints(); // Переписывание Endpoints

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=calendar}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=calendar}/{action=Index}/{id?}/[usersdata]");

app.Run();
