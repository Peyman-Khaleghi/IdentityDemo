using IdentityDemo.Api.Interfaces;
using IdentityDemo.Api.Model;
using IdentityDemo.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer("Server=DESKTOP-9B1LKHD\\PEYMAN;Database=IdentityDemoDb;Integrated Security=true");
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{

}).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        //ValidAudience = Configuration["AuthSettings:Audience"],
        //ValidIssuer = Configuration["AuthSettings:Issuer"],
        RequireExpirationTime = true,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
        ValidateIssuerSigningKey = true
    };
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
