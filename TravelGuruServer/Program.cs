using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TravelGuruServer.Auth;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Data;
using TravelGuruServer.Repositories;

var builder = WebApplication.CreateBuilder(args);



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins("http://localhost:3000",
                                    "http://www.contoso.com");
            });
});


builder.Services.AddControllers();

builder.Services.AddIdentity<TravelUser, IdentityRole>()
    .AddEntityFrameworkStores<TravelDBContext>()
    .AddDefaultTokenProviders();


builder.Services.AddTransient<IRouteRespositories, RouteRespositories>();
builder.Services.AddTransient<IMidWaypointRepositories, MidWaypointRepositories>();
builder.Services.AddTransient<IRouteSectionRepositories, RouteSectionRepositories>();
builder.Services.AddTransient<IRoutePointRepositories, RoutePointRepositories>();
builder.Services.AddTransient<IRImagesUrlRepositories, RImagesUrlRepositories>();
builder.Services.AddTransient<IRRecommendationUrlRepositories, RRecommendationUrlRepositories>();
builder.Services.AddTransient<IAdditionalPointRepositories, AdditionalPointRepositories>();
builder.Services.AddTransient<ICommentRespositories, CommentRespositories>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters.ValidAudience = builder.Configuration["JWT:ValidAudience"];
        options.TokenValidationParameters.ValidIssuer = builder.Configuration["JWT:ValidIssuer"];
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]));
    });
builder.Services.AddCors(cr =>
{
    cr.AddPolicy("allowAll", cp =>
    {
        cp.AllowAnyOrigin();
        cp.AllowAnyMethod();
        cp.AllowAnyHeader();
    });
});

builder.Services.AddDbContext<TravelDBContext>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<AuthDbSeeder>();




var app = builder.Build();

app.UseCors("allowAll");
app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("allowAll");
var dbSeeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<AuthDbSeeder>();
await dbSeeder.SeedAsync();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;
app.Run();
