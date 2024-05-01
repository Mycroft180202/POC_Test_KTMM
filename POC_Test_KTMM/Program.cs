using Microsoft.EntityFrameworkCore;
using POC_Test_KTMM.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<CuaHangTraSuaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Add endpoint for API controllers
app.MapControllers();

app.Run();