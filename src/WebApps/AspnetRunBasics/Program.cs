using AspnetRunBasics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ICatalogService, CatalogService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
});
builder.Services.AddHttpClient<IBasketService, BasketService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
});
builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
});
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
