using GestaoPortfolioInvestimentos.Application.Services;
using GestaoPortfolioInvestimentos.Infrastructure.Context;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using GestaoPortfolioInvestimentos.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using System.Text.Json.Serialization;
using GestaoPortfolioInvestimentos.Domain.Schema;

var builder = WebApplication.CreateBuilder(args);

ConfigureDbContext(builder);
ConfigureInjection(builder);
ConfigureJwtSettings(builder);
ConfigureSwagger(builder);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await ApplyMigrations(app);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

ConfigureCors(app);
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

void ConfigureInjection(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddScoped<IAuthService, AuthService>();
    webApplicationBuilder.Services.AddScoped<IProdutoFinanceiroService, ProdutoFinanceiroService>();
    webApplicationBuilder.Services.AddScoped<ITransacaoInvestimentoService, TransacaoInvestimentoService>();
    webApplicationBuilder.Services.AddScoped<IClienteInvestimentosService, ClienteInvestimentosService>();
    webApplicationBuilder.Services.AddScoped<INotificacaoProdutoVencimentoService, NotificacaoProdutoVencimentoService>();
    webApplicationBuilder.Services.AddTransient<IUserRepository, UserRepository>();
    webApplicationBuilder.Services.AddTransient<IProdutoFinanceiroRepository, ProdutoFinanceiroRepository>();
    webApplicationBuilder.Services.AddTransient<ITransacaoInvestimentosRepository, TransacaoInvestimentosRepository>();
    webApplicationBuilder.Services.AddTransient<IClienteInvestimentosRepository, ClienteInvestimentosRepository>();
    webApplicationBuilder.Services.AddTransient<ITokenService, TokenService>();
    webApplicationBuilder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
}

void ConfigureDbContext(WebApplicationBuilder builder1)
{
    builder1.Services.AddDbContext<SqlDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));
}

static void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestao de Portfólios de Investimento", Version = "v1" });
        //c.SchemaFilter<EnumSchemaFilter>();
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Insira 'Bearer' [espaço] e depois seu token JWT na entrada de texto abaixo.\n\nExemplo: \"Bearer 12345abcdef\""
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    });
}

static void ConfigureJwtSettings(WebApplicationBuilder builder)
{
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
        };
    });
}

void ConfigureCors(WebApplication app)
{
    app.UseCors(builder =>
    {
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
    });
}

static async Task ApplyMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<SqlDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}