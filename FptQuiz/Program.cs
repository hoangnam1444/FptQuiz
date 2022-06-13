using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FptQuiz.Data;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

    builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://*.example.com")
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

 builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
       policy =>
       {
           policy.WithOrigins("http://example.com")
                  .WithHeaders(HeaderNames.ContentType, "x-custom-header");
       });
});
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// For Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectString")));

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

    };


});
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});



builder.Services.AddControllers();
builder.Services.AddDbContext<TestBankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'TestBankContext' not found.")));
builder.Services.AddDbContext<MajorResultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'MajorResultContext' not found.")));
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'UserContext' not found.")));
builder.Services.AddDbContext<UniMajorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'UniMajorContext' not found.")));
builder.Services.AddDbContext<UniContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'UniContext' not found.")));
builder.Services.AddDbContext<TestTypeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'TestTypeContext' not found.")));
builder.Services.AddDbContext<TestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'TestContext' not found.")));
builder.Services.AddDbContext<RolesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'RolesContext' not found.")));
builder.Services.AddDbContext<ResultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'ResultContext' not found.")));
builder.Services.AddDbContext<MajorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'MajorContext' not found.")));
builder.Services.AddDbContext<LearningPartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'LearningPartContext' not found.")));
builder.Services.AddDbContext<CareerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'CareerContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder.WithOrigins("*")
                               .AllowAnyMethod()
                               .AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
