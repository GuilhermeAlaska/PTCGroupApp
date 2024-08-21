using API.Configs;
using Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigs(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddResponseCaching();

builder.Services.AddAuthorization(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

builder.Services.AddSwaggerConfigs();

builder.Services.AddInfra(builder.Configuration);

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();