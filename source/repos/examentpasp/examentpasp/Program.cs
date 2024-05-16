using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using examentpasp.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<examentpaspContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("examentpaspContext")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<examentpaspContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
