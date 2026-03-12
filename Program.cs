using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Services with JSON formatting fix
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // This keeps property names exactly as they are in C# (e.g., "Id", "Name")
        // making them easy to match in your JavaScript code.
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<StoreService>();
builder.Services.AddSingleton<CartService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();