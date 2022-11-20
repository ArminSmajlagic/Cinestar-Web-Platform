using Cinestar_WEB_API;
using Microsoft.OpenApi.Models;
using Servisi.HubConfig;

var builder = WebApplication.CreateBuilder(args);

//-----------------------------------------DODAO DAMIR 
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);



// Add services to the container.
builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = "Cookie";
    config.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookie")
.AddOpenIdConnect("oidc", config =>
{
    // base-address of identityserver
    config.Authority = "https://localhost:7153/";

    config.ClientId = "web.client";

    config.ClientSecret = "SuperSecretPassword";

    config.SaveTokens = true;

    config.ResponseType = "code";

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "cinestar_api", Version = "v1" });
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                    }
                });
});



builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var emailConfig = builder.Configuration
.GetSection("EmailConfiguration")
.Get<Modeli.EmailConfiguration.EmailConfig>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddSignalR();

//outsourceing services registering
builder.Services.AddInfrastructure();

var app = builder.Build();


//---------------------------------DODAO DAMIR
startup.Configure(app);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinestar_WEB_API v1"));

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChartsHub>("/dashboard");
});

app.Run();
