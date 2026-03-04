using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Services
builder.Services.AddControllers();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<StoreService>();
builder.Services.AddSingleton<CartService>(); // Add Busket

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();