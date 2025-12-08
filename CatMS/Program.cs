using CatMS;
using CatMS.Data;
using CatMS.Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CatMS.Auth_IdentityModel.IdentityModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Coon")));




// Add Identity with custom classes and long key
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IAuthService, AuthService>();





// Register the Cat repository
builder.Services.AddScoped<ICatRepository, CatRepository>();
// Register the Buyer 
builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
// Register the Seller repository
builder.Services.AddScoped<ISellerRepostory, SellerRepostory>();
// Register the Cloudinary service
builder.Services.AddScoped<IImageRepository, CloudinaryImageRepository>();



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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
     name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
