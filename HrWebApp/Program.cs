var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/sign-in";
    options.AccessDeniedPath = "/Home/Error";
});

builder.Services.AddAuthorization(options =>
{
    //grant to policy to allow only user who have student requirement
    options.AddPolicy("MustBelongToStudentProfile", 
        policy => policy.RequireClaim("UserCategory", "Student"));
    //grant to policy to allow only user who have recruiter requirement
    options.AddPolicy("RecruiterOnly",
        policy => policy.RequireClaim("UserCategory", "Recruiter"));

    options.AddPolicy("RecruiterAndStudentOnly",
        policy => policy.RequireClaim("UserCategory", "Recruiter").RequireClaim("UserCategory", "Student"));
});
// Add middlewares 
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
