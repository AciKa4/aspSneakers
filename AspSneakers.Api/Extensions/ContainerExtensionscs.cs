using AspSneakers.Api.Core;
using AspSneakers.Application.UseCases.Commands;
using AspSneakers.Application.UseCases.Commands.Brands;
using AspSneakers.Application.UseCases.Commands.Categories;
using AspSneakers.Application.UseCases.Commands.Genders;
using AspSneakers.Application.UseCases.Commands.Orders;
using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.Application.UseCases.Commands.Roles;
using AspSneakers.Application.UseCases.Commands.Sizes;
using AspSneakers.Application.UseCases.Commands.Users;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Application.UseCases.Queries.Brand;
using AspSneakers.Application.UseCases.Queries.Categories;
using AspSneakers.Application.UseCases.Queries.Category;
using AspSneakers.Application.UseCases.Queries.Genders;
using AspSneakers.Application.UseCases.Queries.Orders;
using AspSneakers.Application.UseCases.Queries.Products;
using AspSneakers.Application.UseCases.Queries.Roles;
using AspSneakers.Application.UseCases.Queries.Users;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using AspSneakers.Implementation.UseCases.Commands;
using AspSneakers.Implementation.UseCases.Commands.Brands;
using AspSneakers.Implementation.UseCases.Commands.Categories;
using AspSneakers.Implementation.UseCases.Commands.Genders;
using AspSneakers.Implementation.UseCases.Commands.Orders;
using AspSneakers.Implementation.UseCases.Commands.Products;
using AspSneakers.Implementation.UseCases.Commands.Roles;
using AspSneakers.Implementation.UseCases.Commands.SIzes;
using AspSneakers.Implementation.UseCases.Commands.Users;
using AspSneakers.Implementation.UseCases.Queries.Ef;
using AspSneakers.Implementation.UseCases.Queries.Ef.Brand;
using AspSneakers.Implementation.UseCases.Queries.Ef.Category;
using AspSneakers.Implementation.UseCases.Queries.Ef.Genders;
using AspSneakers.Implementation.UseCases.Queries.Ef.Orders;
using AspSneakers.Implementation.UseCases.Queries.Ef.Products;
using AspSneakers.Implementation.UseCases.Queries.Ef.Roles;
using AspSneakers.Implementation.UseCases.Queries.Ef.Users;
using AspSneakers.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspSneakers.Api.Extensions
{
    public static class ContainerExtensionscs
    {

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<SneakersDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {

           //registration
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();

            services.AddTransient<IGetUserUseCasesQuery, EfGetUserUseCasesQuery>();

            #region Categories
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IFindCategoryQuery, EfFindCategoryQuery>();
            #endregion
            #region Brands
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommnad>();
            #endregion

            #region Roles
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            #endregion

            #region Genders
            services.AddTransient<ICreateGenderCommand, EfCreateGenderCommand>();
            services.AddTransient<IGetGendersQuery, EfGetGendersQuery>();
            services.AddTransient<IUpdateGenderCommand, EfUpdateGenderCommand>();
            services.AddTransient<IDeleteGenderCommand, EfDeleteGenderCommand>();
            #endregion

            #region Users
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            services.AddTransient<IUpdateUseCasesCommand, EfUpdateUserUseCasesCommand>();
            #endregion

            #region Sizes
            services.AddTransient<ICreateSizeCommand, EfCreateSizeCommand>();
            services.AddTransient<IDeleteSizeCommand, EfDeleteSizeCommand>();
            #endregion

            #region Orders
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
            #endregion

            #region Products
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IGetProductsQuery, EfGetProductsQuery>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<IFindProductQuery, EfFindProductQuery>();


            services.AddTransient<ICreatePriceProductCommand, EfCreatePriceProductCommand>();
            services.AddTransient<IDeletePriceProductCommand, EfDeletePriceProductCommand>();

            services.AddTransient<ICreateProductSizesCommand, EfCreateProductSizesCommand>();
            services.AddTransient<IUpdateProductSizesCommand, EfUpdateProductSizesCommand>();
            services.AddTransient<IDeleteProductSizeCommand, EfDeleteProductSizeCommand>();
            #endregion

            #region Validators
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<CreateGenderValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateUserUseCasesValidator>();
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<CreateSizeValidator>();
            services.AddTransient<CreatePriceProducValidator>();
            services.AddTransient<CreateProductSizesValidator>();
            services.AddTransient<UpdateProductValidator>();
            #endregion

        }



        public static void AddSneakersDbContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = x.GetService<AppSettings>().ConnString;

                optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new SneakersDbContext(options);
            });
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }
    }
}
