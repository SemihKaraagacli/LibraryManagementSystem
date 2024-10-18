using FluentValidation;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.Repository.Book.Repositories;
using LibraryManagementSystem.Repository.Context;
using LibraryManagementSystem.Repository.GenericRepositories;
using LibraryManagementSystem.Repository.UnitOfWork;
using LibraryManagementSystem.Repository.Users.Entity;
using LibraryManagementSystem.Services.Auth.Services;
using LibraryManagementSystem.Services.Book.Services;
using LibraryManagementSystem.Services.Book.Validations;
using LibraryManagementSystem.Services.Book.ViewModel;
using LibraryManagementSystem.Services.Mappers;
using LibraryManagementSystem.Services.Users.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Keys"))).SetDefaultKeyLifetime(TimeSpan.FromDays(30));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connection String Configuration
builder.Services.AddDbContext<AppDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");
    x.UseSqlServer(connectionString, sqlServerOption =>
    {
        sqlServerOption.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
    });
});

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 7;

}).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(BaseMapper));
builder.Services.AddTransient<IValidator<CreateBookViewModel>, CreateBookValidation>();
builder.Services.AddTransient<IValidator<BooksViewModel>, UpdateBookValidation>();

//security stamp Doðrulayýcý Ayarlarýný Yapýlandýrma
builder.Services.Configure<SecurityStampValidatorOptions>(option =>
{
    option.ValidationInterval = TimeSpan.FromMinutes(30);
});

// Cookie ayarlarý yapýlanýrma
builder.Services.ConfigureApplicationCookie(options =>
{
    var cookieBuilder = new CookieBuilder
    {
        Name = "LibraryManagementSystemCookie"
    };
    options.LoginPath = new PathString("/Auth/SignIn");
    options.AccessDeniedPath = new PathString("/Home/AccessDenied");
    options.Cookie = cookieBuilder;
    options.ExpireTimeSpan = TimeSpan.FromDays(30); //// Oturum süresi 30 gün
    options.SlidingExpiration = true; // Oturum süresi uzatýlacak
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
