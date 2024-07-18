using System.Runtime.InteropServices;
using API;
using API.Extensions;
using APPLICATION;
using INFRASTRUCTURE;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration
builder.Services.AddSingleton(builder.Configuration);

// Add services to the container.
// Infra dependency injection
InfraInjector.Inject(builder.Services, builder.Configuration);

// App dependency injection
AppInjector.Inject(builder.Services, builder.Configuration);

// Api dependency injection
ApiInjector.Inject(builder.Services, builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseCors(x => x
    .WithOrigins("https://*:3001", "https://*:3001")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders("*")
    .SetIsOriginAllowed(_ => true) // allow any origin
    .AllowCredentials()); // allow credential

// Hosting
var path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? Path.Combine(builder.Configuration["File:LocationWIN32"], builder.Configuration["File:DestinationWIN32"])
    : Path.Combine(builder.Configuration["File:LocationLINUX"], builder.Configuration["File:DestinationLINUX"]);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(path),
    RequestPath = builder.Configuration["File:Request"]
});

app.UseSwaggerAuthorized();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    var title = app.Configuration["App"];

    c.DocumentTitle = title;

    if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
    {
        c.SwaggerEndpoint($"/swagger/{title}/swagger.json", title);
    }
    else
    {
        c.SwaggerEndpoint($"/dev/swagger/{title}/swagger.json", title);
    }

    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();