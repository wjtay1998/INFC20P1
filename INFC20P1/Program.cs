using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using INFC20P1.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<INFC20P1PersonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("INFC20P1PersonContext") ?? throw new InvalidOperationException("Connection string 'INFC20P1PersonContext' not found.")));
builder.Services.AddDbContext<INFC20P1TransactionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("INFC20P1TransactionContext") ?? throw new InvalidOperationException("Connection string 'INFC20P1TransactionContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
