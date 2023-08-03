using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Create database connection string from environment variables
            var db_server = builder.Configuration.GetValue<string>("DB_SERVER");
            var db_port = builder.Configuration.GetValue<string>("DB_PORT") ?? "3306";
            var db_cat = builder.Configuration.GetValue<string>("DB_CATALOGUE");
            var db_user = builder.Configuration.GetValue<string>("DB_USER");
            var db_pw = builder.Configuration.GetValue<string>("DB_PASSWORD");

            var connectionString = $"Server={db_server};Port={db_port};Database={db_cat};Uid={db_user};Pwd={db_pw};";

            // Add database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseMySQL(connectionString));

            //Enable authentication schemes
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("JWT_ISSUER"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT_ENCRYPTION_KEY")))
                };
            })
            .AddDiscord(options =>
            {
                options.ClientId = builder.Configuration.GetValue<string>("DISCORD_CLIENTID") ?? string.Empty;
                options.ClientSecret = builder.Configuration.GetValue<string>("DISCORD_CLIENTSECRET") ?? string.Empty;
                options.CallbackPath = "/signin-discord";
            }).AddCookie();

            // Add services to the container.
            builder.Services.AddSingleton(typeof(LoggerService));
            builder.Services.AddSingleton(typeof(DiscordBotService));

            builder.Services.AddScoped(typeof(TokenClientService));

            builder.Services.AddScoped(typeof(AppUserService));
            builder.Services.AddScoped(typeof(JournalArticleService));
            builder.Services.AddScoped(typeof(ClanService));
            builder.Services.AddScoped(typeof(ClanUserRelationService));
            builder.Services.AddScoped(typeof(NavigationEntryService));
            builder.Services.AddScoped(typeof(ContentPageService));

            builder.Services.AddScoped(typeof(IBaseService<AppUser>), typeof(AppUserService));
            builder.Services.AddScoped(typeof(IBaseService<JournalArticle>), typeof(JournalArticleService));
            builder.Services.AddScoped(typeof(IBaseService<Clan>), typeof(ClanService));
            builder.Services.AddScoped(typeof(IBaseService<ClanUserRelation>), typeof(ClanUserRelationService));
            builder.Services.AddScoped(typeof(IBaseService<NavigationEntry>), typeof(NavigationEntryService));
            builder.Services.AddScoped(typeof(IBaseService<ContentPage>), typeof(ContentPageService));
            builder.Services.AddScoped(typeof(IBaseService<ContentCreator>), typeof(ContentCreatorService));

            builder.Services.AddMemoryCache();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var app = builder.Build();

            // Migrate the database if there are pending updates that have not yet been applied
            DbMigrationService.MigrationInitialization(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TTHQ API V1");
            });

            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Lax
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}