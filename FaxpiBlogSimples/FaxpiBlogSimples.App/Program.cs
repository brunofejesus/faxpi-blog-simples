using FaxpiBlogSimples.Nucleo.Compartilhado;
using FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Servicos;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;

using Microsoft.AspNetCore.Authentication.Cookies;

using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AdicionarNucleo(builder.Configuration);

builder.Services.AddAuthentication(options =>
{
  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
  options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
  options.LoginPath = "/Usuario/Login";
  options.AccessDeniedPath = "/Usuario/Login";
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
}

using var scope = app.Services.CreateScope();
var initialiser = scope.ServiceProvider.GetRequiredService<InicializadorDoContextoDePrincipal>();
await initialiser.InitialiseAsync();
await initialiser.SeedAsync();

app.UseWebSockets();

app.Map("/wsnotificador", async context =>
{
  if (context.WebSockets.IsWebSocketRequest)
  {
    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
    var webSocketManager = context.RequestServices.GetRequiredService<BlogWebSocketManager>();
    await webSocketManager.HandleWebSocketAsync(webSocket);
  }
  else
  {
    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
  }
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();