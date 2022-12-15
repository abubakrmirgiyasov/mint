using Mint.Middleware.Extensions;
using Mint.Middleware.Services.Interfaces;
using Mint.Middleware.Services.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Mint.Admin";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.IsEssential = true;
});

builder.Services.AddCookiePolicy(options =>
{
    options.CheckConsentNeeded = context => false;
    options.OnAppendCookie = context =>
    {
        context.CookieOptions.Expires = DateTimeOffset.UtcNow.AddDays(Params.ExpireTokenTime);
    };
});

builder.Services.AddRazorPages();

builder.Services.AddScoped<ICategoryRequest, CategoryRequest>();
builder.Services.AddScoped<IAdminRequestService, AdminRequestService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCookiePolicy();
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
