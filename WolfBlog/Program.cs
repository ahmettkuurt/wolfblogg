
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using sstoktakip.Controllers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(_ =>
{
	_.Password.RequiredLength = 5;
	_.Password.RequireNonAlphanumeric = false;
	_.Password.RequireLowercase = false;
	_.Password.RequireUppercase = false;
	_.Password.RequireDigit = false;
}).AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
//builder.Services.AddAuthentication(
//        CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie(x =>
//        {
//            x.LoginPath = "/Login/Index";
//        }
//    );

builder.Services.ConfigureApplicationCookie(x =>
{
	x.LoginPath = "/Login";
});
//builder.Services.AddAuthentication().AddCookie(options => options.LoginPath = "/Login/");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Blog}/{action=Index}/{id?}");



app.Run();
