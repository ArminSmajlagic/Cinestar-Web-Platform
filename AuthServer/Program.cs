using AuthServer.Config;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServer()
              .AddInMemoryClients(IDS_Config.Clients)
              .AddInMemoryIdentityResources(IDS_Config.IdentityResources)
              .AddInMemoryApiResources(IDS_Config.ApiResources)
              .AddInMemoryApiScopes(IDS_Config.ApiScopes)
              .AddTestUsers(IDS_Config.testUsers)
              .AddDeveloperSigningCredential();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      "CorsPolicy",
      builder => builder.WithOrigins("http://localhost:4200", "http://localhost:44383")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthServer", Version = "v1" })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("CorsPolicy");


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthServer v1"));
}

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseRouting();

app.MapControllers();

app.Run();
