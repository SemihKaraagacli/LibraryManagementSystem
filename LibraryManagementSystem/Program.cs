using AutoMapper;
using FluentValidation;
using LibraryManagementSystem.Models.Book.Responsities;
using LibraryManagementSystem.Models.Book.Services;
using LibraryManagementSystem.Models.Book.Validations;
using LibraryManagementSystem.Models.Book.ViewModel;
using LibraryManagementSystem.Models.Mappins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));
builder.Services.AddTransient<IValidator<CreateBookViewModel>, CreateValitation>();
builder.Services.AddTransient<IValidator<UpdateBookViewModel>, UpdateValidation>();
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
