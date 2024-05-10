using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tp2ASP.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<tp2ASPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("tp2ASPContext") ?? throw new InvalidOperationException("Connection string 'tp2ASPContext' not found.")));
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

    var context = services.GetRequiredService<tp2ASPContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
