using Mint.Middleware.Services.Interfaces;
using Mint.Middleware.Services.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Mint.Sessions";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

builder.Services.AddCookiePolicy(options =>
{
    options.CheckConsentNeeded = context => false;
    options.OnAppendCookie = context =>
    {
        context.CookieOptions.Expires = DateTimeOffset.UtcNow.AddSeconds(30);
    };
});

builder.Services.AddScoped<IAuthenticationRequest, AuthenticationRequest>();

builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
