using empmanwebapi.Configurations;
using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();

string connect = "Data Source=DESKTOP-IJ24I4D;User Id=sa;Password=07102003;Initial Catalog=StoreWorking;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlServer(connect));
builder.Services.AddDbContext<EmployeesDbContext>(options =>
    options.UseSqlServer(connect));
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(connect));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "JwtIssuer",
        ValidAudience = "JwtAudience", 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iKfolJLNwhnuMayeSPlgVoeJzPYWjCUb"))
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("empmanweb_angular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")  // Địa chỉ frontend Angular
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
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
            new string[] {}
        }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("empmanweb_angular");
app.MapControllers();

app.Run();
