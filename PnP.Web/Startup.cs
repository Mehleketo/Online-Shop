using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using PnP.Services.Deliveries;
using PnP.Services.Products;
using PnP.Services.Shop;
using PnP.Services.Users;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace PnP.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            //
            services.AddScoped<IFavouriteProductService, FavouriteProductService>();
            services.AddScoped<IGroceryListService, GroceryListService>();
            services.AddScoped<IGroceryListItemService, GroceryListItemService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductSubcategoryService, ProductSubcategoryService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();
            services.AddScoped<IProductDiscountService, ProductDiscountService>();
            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<IAddressTypeService, AddressTypeService>();
            services.AddScoped<IContactDetailService, ContactDetailService>();
            services.AddScoped<IDeliveryAddressService, DeliveryAddressService>();
            services.AddScoped<IIdentificationTypeService, IdentificationTypeService>();
            services.AddScoped<ILoyaltyCardService, LoyaltyCardService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IRewardsCardService, RewardsCardService>();
            services.AddScoped<IUserAddressService, UserAddressService>();
            services.AddScoped<IUserStatusService, UserStatusService>();
            services.AddScoped<IUserTypeService, UserTypeService>();

            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDeliveryOptionService, DeliveryOptionService>();
            services.AddScoped<IDeliveryStatusService, DeliveryStatusService>();
            services.AddScoped<IDeliveryTypeService, DeliveryTypeService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<ISalesRecordService, SalesRecordService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<ITrolleyItemService, TrolleyItemService>();
            services.AddScoped<ITrolleyService, TrolleyService>();
            services.AddScoped<ITrolleyStatusService, TrolleyStatusService>();

            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                x.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }}
                });

                x.SwaggerDoc("v1", new Info
                {
                    Title = "PnP API",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Mehleketo Baloyi",
                        Email = "mehleketo.baloyi@gmail.com"
                    }
                });

                x.CustomSchemaIds(y => y.FullName);

                x.DocInclusionPredicate((version, apiDescription) => true);

                x.TagActionsBy(y => new List<string>()
                {
                    y.GroupName
                });
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt =>
                {
                    var settings = opt.SerializerSettings;
                    settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    // dont mess with case of properties
                    var resolver = opt.SerializerSettings.ContractResolver as DefaultContractResolver;
                    resolver.NamingStrategy = null;

                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });

            services.AddCors();

            //Jwt Authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCors(builder =>
                builder
                .WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "PnP API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
