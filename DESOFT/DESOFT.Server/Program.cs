using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using AutoMapper;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Mapping;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Infrastructure;
using DESOFT.Server.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

//Services
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IComicBookService, ComicBookService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

//Repositories
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddTransient<IComicBookRepository, ComicBookRepository>();
builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();


IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

//QuestPDF Configuration

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddPolicy("fixed", context =>
            
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: context.Connection.RemoteIpAddress?.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions{
                        PermitLimit = 10,
                        Window = TimeSpan.FromSeconds(10),
                    }));
});



//AutoMapper

var autoMapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ComicBookMapping());
    mc.AddProfile(new ShoppingCartMapper());
    mc.AddProfile(new ShoppingCartItemMapper());
    mc.AddProfile(new UserMapper());
    mc.AddProfile(new OrderMapping());
});

IMapper mapper = autoMapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddMvc();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("https://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

// 1. Add Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-b61l3yhgpdw5l2m2.us.auth0.com/";
    options.Audience = "http://localhost:5265";
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

// 2. Enable authentication middleware
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseRateLimiter();

app.MapFallbackToFile("/index.html");

app.Run();

