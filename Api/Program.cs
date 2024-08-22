using Api.Configs;
using API.Configs;
using Application.Services;
using Infra;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigs(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddResponseCaching();

builder.Services.AddAuthorization(builder.Configuration);

builder.Services.AddControllers();

NotificationConfig.ConfigureServices(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddSwaggerConfigs();

builder.Services.AddInfra(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
//builder.Services.AddSwaggerGen(c =>
//{
//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "JWT Authentication",
//        Description = "Enter JWT Bearer token **_only_**",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }
//    };

//    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            securityScheme, new List<string>()
//        }
//    });

//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "API",
//        Version = "v1"
//    });
//});
app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.MapControllers();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(static endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notificationHub");
});

app.Run();