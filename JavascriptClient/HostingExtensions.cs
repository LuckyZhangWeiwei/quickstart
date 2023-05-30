//using Duende.Bff.Yarp;
//using System.IdentityModel.Tokens.Jwt;

//namespace JavascriptClient
//{
//    internal static class HostingExtensions
//    {
//        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
//        {
//            var services = builder.Services;

//            services.AddControllers();
//            services.AddAuthorization();

//            services.AddBff().AddRemoteApis();

//            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

//            services.AddAuthentication(options =>
//            {
//                options.DefaultScheme = "Cookies";
//                options.DefaultChallengeScheme = "oidc";
//                options.DefaultSignOutScheme = "oidc";
//            })
//            .AddCookie("Cookies")
//            .AddOpenIdConnect("oidc", options =>
//            {
//                options.Authority = "https://localhost:5001";

//                options.ClientId = "bff";
//                options.ClientSecret = "secret";
//                options.ResponseType = "code";

//                options.Scope.Add("api1");

//                options.SaveTokens = true;
//                options.GetClaimsFromUserInfoEndpoint = true;
//            });

//            return builder.Build();
//        }

//        public static WebApplication ConfigurePipeline(this WebApplication app)
//        {
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseDefaultFiles();
//            app.UseStaticFiles();

//            app.UseRouting();
//            app.UseAuthentication();

//            app.UseBff();

//            app.UseAuthorization();

//            //app.UseEndpoints(endpoints =>
//            //{
//            //    endpoints.MapControllers()
//            //        .AsBffApiEndpoint();

//            //    endpoints.MapBffManagementEndpoints();

//            //    endpoints.MapRemoteBffApiEndpoint("/remote", "https://localhost:6001")
//            //        .RequireAccessToken(Duende.Bff.TokenType.User);

//            //});

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapBffManagementEndpoints();
//                // Uncomment this for Controller support
//                // endpoints.MapControllers()
//                //     .AsBffApiEndpoint();
//                endpoints.MapGet("/local/identity", LocalIdentityHandler)
//                    .AsBffApiEndpoint();
//                endpoints.MapRemoteBffApiEndpoint("/remote", "https://localhost:6001")
//                    .RequireAccessToken(Duende.Bff.TokenType.User);
//            });



//            return app;
//        }

//        [Authorize]
//        static IResult LocalIdentityHandler(ClaimsPrincipal user, HttpContext context)
//        {
//            var name = user.FindFirst("name")?.Value ?? user.FindFirst("sub")?.Value;
//            return Results.Json(new { message = "Local API Success!", user = name });
//        }
//    }
//}
