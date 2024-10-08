using FluentValidation;
using LibraryManagementSystem_EFCore_.Models.Book.Repositories;
using LibraryManagementSystem_EFCore_.Models.Book.Services;
using LibraryManagementSystem_EFCore_.Models.Book.Validations;
using LibraryManagementSystem_EFCore_.Models.Book.ViewModel;
using LibraryManagementSystem_EFCore_.Models.Context;
using LibraryManagementSystem_EFCore_.Models.Mappers;
using LibraryManagementSystem_EFCore_.Models.Repositories;
using LibraryManagementSystem_EFCore_.Models.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connection String Configuration
builder.Services.AddDbContext<AppDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");
    x.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddAutoMapper(typeof(BaseMapper));
builder.Services.AddTransient<IValidator<CreateBookViewModel>, CreateBookValidation>();
builder.Services.AddTransient<IValidator<BooksViewModel>, UpdateBookValidation>();


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
